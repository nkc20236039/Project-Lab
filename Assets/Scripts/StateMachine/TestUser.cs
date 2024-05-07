using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StateMachineDemo : MonoBehaviour
{

    public enum StateType
    {
        Idle,
        Run,
        Jump,
    }

    public enum TriggerType
    {
        KeyDownI,
        KeyDownJ,
        KeyDownR,
    }

    private StateMachine<StateType, TriggerType> _stateMachine;

    private void Start()
    {
        // StateMachineを生成
        _stateMachine = new StateMachine<StateType, TriggerType>(this, StateType.Idle);

        // 遷移情報を登録
        _stateMachine.AddTransition(StateType.Idle, StateType.Run, TriggerType.KeyDownR);
        _stateMachine.AddTransition(StateType.Idle, StateType.Jump, TriggerType.KeyDownJ);
        _stateMachine.AddTransition(StateType.Run, StateType.Idle, TriggerType.KeyDownI);
        _stateMachine.AddTransition(StateType.Jump, StateType.Idle, TriggerType.KeyDownI);

        // Stateごとのふるまいを登録
        _stateMachine.SetupState(StateType.Idle, () => Debug.Log("OnEnter: Idle"), () => EnterRoutine(StateType.Idle), () => Debug.Log("OnExit ; Idle"), () => ExitRoutine(StateType.Idle));
        _stateMachine.SetupState(StateType.Run, () => Debug.Log("OnEnter: Run"), () => EnterRoutine(StateType.Run), () => Debug.Log("OnExit ; Run"), () => ExitRoutine(StateType.Run));
        _stateMachine.SetupState(StateType.Jump, () => Debug.Log("OnEnter: Jump"), () => EnterRoutine(StateType.Jump), () => Debug.Log("OnExit ; Jump"), () => ExitRoutine(StateType.Jump));
    }

    private void Update()
    {
        // トリガーを呼ぶ
        if (Input.GetKeyDown(KeyCode.I)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownI);
        if (Input.GetKeyDown(KeyCode.J)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownJ);
        if (Input.GetKeyDown(KeyCode.R)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownR);

        // ステートマシンを更新
        _stateMachine.Update(Time.deltaTime);
    }

    private IEnumerator EnterRoutine(StateType stateType)
    {
        Debug.Log(stateType + " : Enter routine start.");
        yield return new WaitForSeconds(1);
        Debug.Log(stateType + " : Enter routine end.");
    }

    private IEnumerator ExitRoutine(StateType stateType)
    {
        Debug.Log(stateType + " : Enter routine start.");
        yield return new WaitForSeconds(1);
        Debug.Log(stateType + " : Enter routine end.");
    }
}