using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using UnityEngine;

// �eState����delagate��o�^���Ă����N���X
public class StateMapping
{
    public Action onEnter;
    public Func<IEnumerator> EnterRoutine;
    public Action onExit;
    public Func<IEnumerator> ExitRoutine;
    public Action<float> onUpdate;
}

public class Transition<TState, TTrigger>
{
    public TState To { get; set; }
    public TTrigger Trigger { get; set; }
}

public class StateMachine<TState, TTrigger>
    where TState : struct, IConvertible, IComparable
    where TTrigger : struct, IConvertible, IComparable
{
    private MonoBehaviour _monoBehaviour;
    private TState _stateType;
    private StateMapping _stateMapping;
    // �J�ڒ��ł���ꍇ�̑J�ڐ�
    private TState? _destinationState;
    // �J�ڒ���
    private bool _inExitTransition;
    private bool _inEnterTransition;

    private Dictionary<object, StateMapping> _stateMappings = new Dictionary<object, StateMapping>();
    private Dictionary<TState, List<Transition<TState, TTrigger>>> _transitionLists = new Dictionary<TState, List<Transition<TState, TTrigger>>>();

    public StateMachine(MonoBehaviour monoBehaviour, TState initialState)
    {
        _monoBehaviour = monoBehaviour;

        // State����StateMapping���쐬
        var enumValues = Enum.GetValues(typeof(TState));
        for (int i = 0; i < enumValues.Length; i++)
        {
            var mapping = new StateMapping();
            _stateMappings.Add(enumValues.GetValue(i), mapping);
        }

        // �ŏ���State�ɑJ��
        ChangeStateImmediately(initialState);
    }

    /// <summary>
    /// �g���K�[�����s����
    /// </summary>
    public void ExecuteTrigger(TTrigger trigger)
    {
        var transitions = _transitionLists[_stateType];
        foreach (var transition in transitions)
        {
            if (transition.Trigger.Equals(trigger))
            {
                _monoBehaviour.StartCoroutine(ChangeState(transition.To));
                break;
            }
        }
    }

    /// <summary>
    /// �J�ڏ���o�^����
    /// </summary>
    public void AddTransition(TState from, TState to, TTrigger trigger)
    {
        if (!_transitionLists.ContainsKey(from))
        {
            _transitionLists.Add(from, new List<Transition<TState, TTrigger>>());
        }
        var transitions = _transitionLists[from];
        var transition = transitions.FirstOrDefault(x => x.To.Equals(to));
        if (transition == null)
        {
            // �V�K�o�^
            transitions.Add(new Transition<TState, TTrigger> { To = to, Trigger = trigger });
        }
        else
        {
            // �X�V
            transition.To = to;
            transition.Trigger = trigger;
        }
    }

    /// <summary>
    /// State������������
    /// </summary>
    public void SetupState(TState state, Action onEnter = null, Func<IEnumerator> enterRoutine = null, Action onExit = null, Func<IEnumerator> exitRoutine = null, Action<float> onUpdate = null)
    {
        var stateMapping = _stateMappings[state];
        stateMapping.onEnter = onEnter;
        stateMapping.EnterRoutine = enterRoutine;
        stateMapping.onExit = onExit;
        stateMapping.ExitRoutine = exitRoutine;
        stateMapping.onUpdate = onUpdate;
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    public void Update(float deltaTime)
    {
        if (_inExitTransition || _inEnterTransition)
        {
            // �J�ڒ��͍X�V���Ȃ�
            return;
        }
        if (_stateMapping != null && _stateMapping.onUpdate != null)
        {
            _stateMapping.onUpdate(deltaTime);
        }
    }

    /// <summary>
    /// State���������ɕύX����
    /// </summary>
    private void ChangeStateImmediately(TState to)
    {
        // Exit
        if (_stateMapping != null)
        {
            if (_stateMapping.onExit != null)
            {
                _stateMapping.onExit();
            }
        }

        // Enter
        _stateType = to;
        _stateMapping = _stateMappings[_stateType];
        if (_stateMapping.onEnter != null)
        {
            _stateMapping.onEnter();
        }
    }

    /// <summary>
    /// State��ύX����
    /// </summary>
    private IEnumerator ChangeState(TState to)
    {
        if (_inEnterTransition)
        {
            // Enter�J�ڒ��������牽������break�i��ԑJ�ڎ��s�j
            yield break;
        }

        _destinationState = to;
        if (_inExitTransition)
        {
            // Exit�J�ڒ���������J�ڐ���㏑������break
            yield break;
        }


        // Exit
        _inExitTransition = true;
        if (_stateMapping != null)
        {
            if (_stateMapping.ExitRoutine != null)
            {
                yield return _monoBehaviour.StartCoroutine(_stateMapping.ExitRoutine());
            }
            if (_stateMapping.onExit != null)
            {
                _stateMapping.onExit();
            }
        }
        _inExitTransition = false;

        // Enter
        _inEnterTransition = true;
        var stateMapping = _stateMappings[_destinationState.Value];
        if (stateMapping.EnterRoutine != null)
        {
            yield return stateMapping.EnterRoutine();
        }
        if (stateMapping.onEnter != null)
        {
            stateMapping.onEnter();
        }
        _inEnterTransition = false;
        // State����������
        _stateType = _destinationState.Value;
        _stateMapping = _stateMappings[_stateType];

        _destinationState = null;
    }
}
