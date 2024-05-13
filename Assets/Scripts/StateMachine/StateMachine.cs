using System;
using System.Collections.Generic;

public class StateMachine
{
    private bool isEnable;
    private IState currentState;
    private Dictionary<Enum, IState> stateDictionary;
    private VoidState voidState;

    public StateMachine(bool isThrowException = false)
    {
        stateDictionary = new();
        voidState = new(isThrowException);
    }

    /// <summary>
    /// StateMachine�̗L�����
    /// </summary>
    public bool IsEnable => isEnable;

    /// <summary>
    /// �P�t���[���̍X�V�����Ƃ��Ďg�p���܂�
    /// </summary>
    public void Update()
    {
        currentState.OnUpdate();

        if (!isEnable)
        {
            // ������ԂȂ玟�̏�Ԍ��؂����Ȃ�
            return;
        }

        Enum receivedNextState = currentState.NextStateComparison();

        if (stateDictionary[receivedNextState] != currentState)
        {
            // �󂯎������Ԃ����݂̏�Ԃƈ�������Ԃ�ύX����
            ChangeState(receivedNextState);
        }
    }

    /// <summary>
    /// �V������Ԃ�o�^���܂�
    /// </summary>
    /// <param name="key">��Ԃ�o�^����񋓎q</param>
    /// <param name="value">��Ԃ̃C���X�^���X</param>
    /// <param name="isOverride">�C���X�^���X���V���O���g���ɂ��܂�</param>
    public void Register(Enum key, IState value, bool isOverride = false)
    {
        if (!(stateDictionary.TryAdd(key, value) && isOverride))
        {
            stateDictionary[key] = value;
        }
    }

    /// <summary>
    /// ��Ԃ̓o�^����������
    /// </summary>
    /// <param name="key">���������Ԃ̃L�[</param>
    /// <param name="isForce">���ݏ�Ԃ����s���Ă��Ă������I�ɍ폜����</param>
    public void Unregister(Enum key, bool isForce = true)
    {
        if (!stateDictionary.ContainsKey(key))
        {
            // ��Ԃ����ɑ��݂��Ȃ���Ζ�������
            return;
        }

        if (isForce || stateDictionary[key] != currentState)
        {
            // �����폜���邩��Ԃ��ʂ̎��͍폜����
            stateDictionary.Remove(key);
        }
    }

    /// <summary>
    /// StateMachine��L��������
    /// </summary>
    /// <param name="initalState">�����̏��</param>
    public void Enable(Enum initalState)
    {
        ChangeState(initalState);

        isEnable = true;
    }

    /// <summary>
    /// StateMachine�𖳌������܂�
    /// </summary>
    public void Disable()
    {
        if (isEnable)
        {
            // �I���������Ăяo���Ė�����
            currentState.OnExit();
            isEnable = false;

            // ������Ԃ�}��
            currentState = voidState;
        }
    }

    /// <summary>
    /// ���݂̏�Ԃ�string�^�ŕԂ��܂�
    /// </summary>
    /// <returns></returns>
    public string GetStateString() => currentState.ToString();

    /// <summary>
    /// ��Ԃ��X�V
    /// </summary>
    /// <param name="state">���ɍX�V������</param>
    private void ChangeState(Enum state)
    {
        if (currentState != null)
        {
            // ��Ԃ�����ΑO��̏I���������Ăяo��
            currentState.OnExit();
        }

        // �V������Ԃ�o�^
        currentState = stateDictionary[state];

        currentState.OnEnter();
    }

    private void VerifyNextState()
    {
        
    }

    private class VoidState : IState
    {
        private bool isThrowException;
        private Exception ex = new("��Ԃ͖����ł�");

        public VoidState(bool isThrowException)
        {
            this.isThrowException = isThrowException;
        }

        Enum IState.NextStateComparison()
        {
            throw ex;
        }

        void IState.OnEnter() { ThrowException(); }

        void IState.OnExit() { ThrowException(); }

        void IState.OnUpdate() { ThrowException(); }

        private void ThrowException()
        {
            if (isThrowException)
            {
                throw ex;
            }
        }
    }
}