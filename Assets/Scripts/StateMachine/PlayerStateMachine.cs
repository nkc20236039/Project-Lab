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
            // 新しいstateを登録
            currentPlayerState = value;
            currentStateInstance = serviceLocator.Get(value);

            currentStateInstance.OnEnter();
        }
    }

    public PlayerStateMachine(PlayerDataTransfer playerDataTransfer)
    {
        // それぞれのstateを登録

    }

    public void OnUpdate()
    {
        currentStateInstance.OnUpdate();
    }
}