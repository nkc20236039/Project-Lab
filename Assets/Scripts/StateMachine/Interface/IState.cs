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
    public void OnFixedUpdate() { return; }

    /// <summary>
    /// state�I�������s
    /// </summary>
    public void OnExit();
}