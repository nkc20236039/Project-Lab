using System;
using System.Numerics;

public class MoveState : IState
{
    public event Action<Vector3> OnMoved;

    public float Speed { get; set; }

    public IMovable MovementVector { get; set; }

    public void UpdateState()
    {
        // ���x����Z
        Vector3 scaledVector = MovementVector.MovementVector * Speed;

        // �ړ���K�p
        OnMoved(scaledVector);
    }

    public void OnEnter()
    {
        throw new NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }
}