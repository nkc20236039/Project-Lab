using UnityEngine;

public interface IState
{
    /// <summary>
    /// state遷移時実行
    /// </summary>
    public void OnEnter();

    /// <summary>
    /// state時実行
    /// </summary>
    public void OnUpdate();

    /// <summary>
    /// state時物理計算用実行
    /// </summary>
    public Vector3 OnFixedUpdate() { return default; }

    /// <summary>
    /// state終了時実行
    /// </summary>
    public void OnExit();
}