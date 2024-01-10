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
            // �V����state��o�^
            currentPlayerState = value;
            currentStateInstance = serviceLocator.Get(value);

            currentStateInstance.OnEnter();
        }
    }

    public PlayerStateMachine(PlayerDataTransfer playerDataTransfer)
    {
        // ���ꂼ���state��o�^

    }

    public void OnUpdate()
    {
        currentStateInstance.OnUpdate();
    }
}