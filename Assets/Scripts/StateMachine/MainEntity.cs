using UnityEngine;



public sealed class MainEntity: MonoBehaviour
{
    StateMachine stateMachine;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // StateMachineを取得する
        stateMachine = ServiceLocator<StateMachine>.Get();
    }

    private void Update()
    {
        
    }
}