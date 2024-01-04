using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasState
{
    public void ChangeState()
    {
        
    }

    /// <summary>
    /// 状態の始まりに呼び出す
    /// </summary>
    public void OnEnter();

    /// <summary>
    /// 状態の間毎フレーム呼ばれ続ける
    /// </summary>
    public void OnUpdate();

    /// <summary>
    /// 状態の間定期的に呼ばれる
    /// </summary>
    public void OnFixedUpdate(Vector2 velocity) { }

    /// <summary>
    /// 状態の終了時に呼ばれる
    /// </summary>
    public void OnExit();
}
