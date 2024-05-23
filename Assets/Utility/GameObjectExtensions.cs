using System;
using UnityEngine;

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
}
