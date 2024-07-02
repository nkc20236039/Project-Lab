using System;
using UnityEngine;

public interface IState
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();

    public Enum NextStateComparison();
}

public abstract class AbstractEntityState
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}