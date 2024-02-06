using UnityEngine;



public sealed class MainEntity: MonoBehaviour
{
    StateMachine stateMachine;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // StateMachine‚ðŽæ“¾‚·‚é
        stateMachine = ServiceLocator<StateMachine>.Get();
    }

    private void Update()
    {
        
    }
}