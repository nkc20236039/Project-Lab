using System;
using UnityEngine;

public interface IStateMachine<T>
    where T : Enum
{
    public T CurrentState { get; set; }

    public void OnUpdate();
    public void OnFixedUpdate(Vector2 velocity);
}