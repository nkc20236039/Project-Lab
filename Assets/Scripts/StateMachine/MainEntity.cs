using System;
using System.Numerics;

public class MoveState
{
    public float Speed { get; set; }

    public IMovementVector MovementVector { get; set; }

    public void UpdateState()
    {
        // �ړ��x�N�g�����擾
        var movement = MovementVector.GetMovementVector();

        // ���x���|����
        var scaledVector = movement * Speed;

        // �ړ���K�p (�ړ������͊O���ōs��)
        OnMoved(scaledVector);
    }

    public event Action<Vector2> OnMoved;
}

// IMovementVector �C���^�[�t�F�C�X
public interface IMovementVector
{
    Vector2 GetMovementVector();
}