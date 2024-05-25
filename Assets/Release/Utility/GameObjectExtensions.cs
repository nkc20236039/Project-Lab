using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameObjectExtensions
{
    /// <summary>
    /// ���C���[����v���Ă��邩���ׂ܂�
    /// </summary>
    /// <param name="layer">�Ώۂ̃��C���[</param>
    /// <param name="layerMask">��r���郌�C���[�}�X�N</param>
    /// <returns></returns>
    public static bool IsLayersMatch(this GameObject gameObject, LayerMask layerMask)
    {
        // layerMask��Everything(-1)�Ȃ�true�ɂ���
        if ((int)layerMask == -1)
        {
            return true;
        }

        // layer���i���ɕϊ�
        string bitString = Convert.ToString((int)layerMask, 2);
        int bit = 0;

        try
        {
            // string�^��bit��int�ɕϊ�
            bit = int.Parse(bitString);
        }
        catch
        {
            // �ϊ��ł��Ȃ����false��Ԃ�
            return false;
        }

        // bit�ƃ��C���[�̔ԍ����V�t�g��������and���Z
        int matchBit = bit & 1 << gameObject.layer;

        // �ǂ�����1������Έ�v���Ă���̂�true��Ԃ��A�Ȃ����false
        return matchBit != 0;
    }

    // TODO: scene��Enum��
    // TODO: SceneManager.LoadScene()��Enum���g���I�[�o�[���[�h

    /// <summary>
    /// root�I�u�W�F�N�g��Transform�̎擾�����݂܂�
    /// </summary>
    public static Transform TryGetRoot(this Transform child)
    {
        if (child.parent == null)
        {
            return child;
        }

        return child.root;
    }

    public static Transform[] GetChildren(this Transform parent)
    {
        Transform[] children = new Transform[parent.childCount];

        for (int i = 0; i < children.Length; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }

    public static Transform[] GetIgnoreParentFamily(this Transform parent)
    {
        Transform[] family = parent.GetComponentsInChildren<Transform>(true);

        Transform[] ignoreParentFamily = new Transform[family.Length - 1];

        Array.Copy(family, 1, ignoreParentFamily, 0, ignoreParentFamily.Length);

        return ignoreParentFamily;
    }
}