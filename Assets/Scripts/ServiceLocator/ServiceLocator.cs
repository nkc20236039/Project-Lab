using System.Collections.Generic;
using System;

public static class ServiceLocator<T>
{
    private static Dictionary<Type, T> instanceDic = new();

    /// <summary>
    /// �C���X�^���X��o�^����
    /// </summary>
    /// <param name="index"></param>
    /// <param name="instance"></param>
    public static void Register(T instance)
    {
        if (!instanceDic.TryAdd(typeof(T), instance))
        {
            instanceDic[typeof(T)] = instance;
        }
    }

    /// <summary>
    /// �C���X�^���X�����o��
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get()
    {
        // �Y����Type�����݂��Ȃ����default��Ԃ�
        if (instanceDic.ContainsKey(typeof(T)))
        {
            return instanceDic[typeof(T)];
        }

        return default;
    }
}