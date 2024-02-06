using System;
using System.Collections.Generic;

public class StateMachineLocator
{
	private Dictionary<int, IState> instanceDic = new();

	/// <summary>
	/// �w��̏�Ԃ̃C���X�^���X��o�^����
	/// </summary>
	/// <param name="state">�w��̏��</param>
	/// <param name="instance">�o�^�������C���X�^���X</param>
	/// <param name="overwrite">���ɑ��݂����ꍇ�ɏ㏑������</param>
	public void Register(int state, IState instance, bool overwrite = false)
	{
		// �ǉ������݂� ���ɂ���Ώ㏑�����邩�ɉ����ď�������
		if (!instanceDic.TryAdd(state, instance) && overwrite)
		{
			instanceDic[state] = instance;
		}
	}

	/// <summary>
	/// �w��̏�Ԃ̃C���X�^���X���擾����
	/// </summary>
	/// <param name="state">�擾���������</param>
	public IState Get(int state)
	{
		if (instanceDic.ContainsKey(state))
		{
			return instanceDic[state];
		}

		return default;
	}
}