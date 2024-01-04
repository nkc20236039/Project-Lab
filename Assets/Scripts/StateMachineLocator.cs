using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineLocator<TState>
	where TState : Enum
{
	private Dictionary<TState, IHasState> instanceDic = new();

	/// <summary>
	/// 指定の状態のインスタンスを登録する
	/// </summary>
	/// <param name="state">指定の状態</param>
	/// <param name="instance">登録したいインスタンス</param>
	/// <param name="overwrite">既に存在した場合に上書きする</param>
	public void Register<TInstance>(TState state, TInstance instance, bool overwrite = false)
		where TInstance : IHasState
    {
		// 追加を試みて 既にあれば上書きするかに応じて処理する
		if(!instanceDic.TryAdd(state, instance) && overwrite)
		{
			instanceDic[state] = instance;
		}
	}

	/// <summary>
	/// 指定の状態のインスタンスを取得する
	/// </summary>
	/// <param name="state">取得したい状態</param>
	public TInstance Get<TInstance>(TState state)
    {
		if (instanceDic.ContainsKey(state))
		{
			return (TInstance)instanceDic[state];
		}

		Debug.LogWarning($"不明なstate[{state}]");
		return default;
	}
}