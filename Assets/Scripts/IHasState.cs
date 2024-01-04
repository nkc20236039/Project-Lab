using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasState
{
    public void ChangeState()
    {
        
    }

    /// <summary>
    /// ��Ԃ̎n�܂�ɌĂяo��
    /// </summary>
    public void OnEnter();

    /// <summary>
    /// ��Ԃ̊Ԗ��t���[���Ă΂ꑱ����
    /// </summary>
    public void OnUpdate();

    /// <summary>
    /// ��Ԃ̊Ԓ���I�ɌĂ΂��
    /// </summary>
    public void OnFixedUpdate(Vector2 velocity) { }

    /// <summary>
    /// ��Ԃ̏I�����ɌĂ΂��
    /// </summary>
    public void OnExit();
}
