public enum PlayerState
{
    
}

public class PlayerStateMachine
{
    private StateMachineLocator<PlayerState> serviceLocator;
    private PlayerState currentPlayerState;
    private IState currentStateInstance;

    public PlayerState CurrentPlayerState
    {
        get => currentPlayerState;
        set
        {
            currentStateInstance.OnExit();
            // V‚µ‚¢state‚ğ“o˜^
            currentPlayerState = value;
            currentStateInstance = serviceLocator.Get(value);

            currentStateInstance.OnEnter();
        }
    }

    public PlayerStateMachine(PlayerDataTransfer playerDataTransfer)
    {
        // ‚»‚ê‚¼‚ê‚Ìstate‚ğ“o˜^

    }

    public void OnUpdate()
    {
        currentStateInstance.OnUpdate();
    }
}