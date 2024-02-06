using System;
using System.Numerics;

public class MoveState : IState
{
    public event Action<Vector3> OnMoved;

    public float Speed { get; set; }

    public IMovable MovementVector { get; set; }

    public void UpdateState()
    {
        // 速度を乗算
        Vector3 scaledVector = MovementVector.MovementVector * Speed;

        // 移動を適用
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