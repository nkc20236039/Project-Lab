using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour 
    where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                // インスタンスが空だったら存在するインスタンスを見つける
                instance = (T)FindObjectOfType(typeof(T));
                // 見つからなかったらnull
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if(Instance != null)
        {
            // 既にインスタンスが存在したら破棄
            Destroy(this.gameObject);
        }
    }
}
