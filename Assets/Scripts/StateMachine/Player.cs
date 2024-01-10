using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private PlayerDataTransfer playerDataTransfer;

    private void Start()
    {
        playerDataTransfer = new()
        {
            PlayerRigidbody = GetComponent<Rigidbody>()
        };

        stateMachine = new(playerDataTransfer);
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }
}