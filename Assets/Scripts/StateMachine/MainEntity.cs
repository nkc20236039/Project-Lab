using System;
using System.Numerics;

public class MoveState
{
    public float Speed { get; set; }

    public IMovementVector MovementVector { get; set; }

    public void UpdateState()
    {
        // 移動ベクトルを取得
        var movement = MovementVector.GetMovementVector();

        // 速度を掛ける
        var scaledVector = movement * Speed;

        // 移動を適用 (移動処理は外部で行う)
        OnMoved(scaledVector);
    }

    public event Action<Vector2> OnMoved;
}

// IMovementVector インターフェイス
public interface IMovementVector
{
    Vector2 GetMovementVector();
}