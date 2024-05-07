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
        // StateMachine‚ğ¶¬
        _stateMachine = new StateMachine<StateType, TriggerType>(this, StateType.Idle);

        // ‘JˆÚî•ñ‚ğ“o˜^
        _stateMachine.AddTransition(StateType.Idle, StateType.Run, TriggerType.KeyDownR);
        _stateMachine.AddTransition(StateType.Idle, StateType.Jump, TriggerType.KeyDownJ);
        _stateMachine.AddTransition(StateType.Run, StateType.Idle, TriggerType.KeyDownI);
        _stateMachine.AddTransition(StateType.Jump, StateType.Idle, TriggerType.KeyDownI);

        // State‚²‚Æ‚Ì‚Ó‚é‚Ü‚¢‚ğ“o˜^
        _stateMachine.SetupState(StateType.Idle, () => Debug.Log("OnEnter: Idle"), () => EnterRoutine(StateType.Idle), () => Debug.Log("OnExit ; Idle"), () => ExitRoutine(StateType.Idle));
        _stateMachine.SetupState(StateType.Run, () => Debug.Log("OnEnter: Run"), () => EnterRoutine(StateType.Run), () => Debug.Log("OnExit ; Run"), () => ExitRoutine(StateType.Run));
        _stateMachine.SetupState(StateType.Jump, () => Debug.Log("OnEnter: Jump"), () => EnterRoutine(StateType.Jump), () => Debug.Log("OnExit ; Jump"), () => ExitRoutine(StateType.Jump));
    }

    private void Update()
    {
        // ƒgƒŠƒK[‚ğŒÄ‚Ô
        if (Input.GetKeyDown(KeyCode.I)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownI);
        if (Input.GetKeyDown(KeyCode.J)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownJ);
        if (Input.GetKeyDown(KeyCode.R)) _stateMachine.ExecuteTrigger(TriggerType.KeyDownR);

        // ƒXƒe[ƒgƒ}ƒVƒ“‚ğXV
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