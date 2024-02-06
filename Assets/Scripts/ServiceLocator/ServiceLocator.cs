using System.Collections.Generic;
using System;

public static class ServiceLocator<T>
{
    private static Dictionary<Type, T> instanceDic = new();

    /// <summary>
    /// インスタンスを登録する
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
    /// インスタンスを取り出す
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get()
    {
        // 該当のTypeが存在しなければdefaultを返す
        if (instanceDic.ContainsKey(typeof(T)))
        {
            return instanceDic[typeof(T)];
        }

        return default;
    }
}