using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineLocator<TState>
	where TState : Enum
{
	private Dictionary<TState, IHasState> instanceDic = new();

	/// <summary>
	/// �w��̏�Ԃ̃C���X�^���X��o�^����
	/// </summary>
	/// <param name="state">�w��̏��</param>
	/// <param name="instance">�o�^�������C���X�^���X</param>
	/// <param name="overwrite">���ɑ��݂����ꍇ�ɏ㏑������</param>
	public void Register<TInstance>(TState state, TInstance instance, bool overwrite = false)
		where TInstance : IHasState
    {
		// �ǉ������݂� ���ɂ���Ώ㏑�����邩�ɉ����ď�������
		if(!instanceDic.TryAdd(state, instance) && overwrite)
		{
			instanceDic[state] = instance;
		}
	}

	/// <summary>
	/// �w��̏�Ԃ̃C���X�^���X���擾����
	/// </summary>
	/// <param name="state">�擾���������</param>
	public TInstance Get<TInstance>(TState state)
    {
		if (instanceDic.ContainsKey(state))
		{
			return (TInstance)instanceDic[state];
		}

		Debug.LogWarning($"�s����state[{state}]");
		return default;
	}
}