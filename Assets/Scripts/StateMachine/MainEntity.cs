using UnityEngine;



public sealed class MainEntity: MonoBehaviour
{
    StateMachine stateMachine;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // StateMachine���擾����
        stateMachine = ServiceLocator<StateMachine>.Get();
    }

    private void Update()
    {
        
    }
}