using UnityEngine;
public class PlayerDataTransfer
{
    private Vector3 inputDirectoin;

    public Vector3 InputDirection
    {
        get => inputDirectoin;
        set => inputDirectoin = value.normalized;
    }

    public Rigidbody PlayerRigidbody { get; set; }
}