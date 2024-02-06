public enum MainEntityState
{
    Idle,
    Move,
    Jump,
    Fall,
}

public class MainEntityStateRule
{
    public MainEntityStateRule(StateMachineLocator serviceLocator)
    {
        serviceLocator.Register((int)MainEntityState.Idle, new MoveState());
    }
}