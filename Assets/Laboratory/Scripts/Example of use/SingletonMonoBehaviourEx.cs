using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviourEx : SingletonMonoBehaviour<SingletonMonoBehaviourEx>
{
    // SingletonMonoBehaviour�N���X���p�������邱�Ƃ�
    // �I�u�W�F�N�g���V���O���g���ɂ��邱�Ƃ��ł���
    // Awake��override����ꍇ��base���Ăяo������

    void Start()
    {
        Debug.Log($"���̃N���X�̃C���X�^���X��{Instance}");
    }

    protected override void Awake()
    {
        base.Awake();
        Debug.Log($"����������");
    }
}
