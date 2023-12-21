using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviourEx : SingletonMonoBehaviour<SingletonMonoBehaviourEx>
{
    // SingletonMonoBehaviourクラスを継承させることで
    // オブジェクトをシングルトンにすることができる
    // Awakeをoverrideする場合はbaseを呼び出すこと

    void Start()
    {
        Debug.Log($"このクラスのインスタンスは{Instance}");
    }

    protected override void Awake()
    {
        base.Awake();
        Debug.Log($"初期化処理");
    }
}
