using UnityEngine;

public interface IState
{
    /// <summary>
    /// state�J�ڎ����s
    /// </summary>
    public void OnEnter();

    /// <summary>
    /// state�����s
    /// </summary>
    public void OnUpdate();

    /// <summary>
    /// state�������v�Z�p���s
    /// </summary>
    public Vector3 OnFixedUpdate() { return default; }

    /// <summary>
    /// state�I�������s
    /// </summary>
    public void OnExit();
}