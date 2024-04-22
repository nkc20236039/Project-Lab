using System;
using System.Collections.Generic;

public class StateMachine<TStateEnum>
    where TStateEnum : Enum
{
    private bool isEnable;
    private IState currentState;
    private Dictionary<TStateEnum, IState> stateDictionary;
    private VoidState voidState;

    public StateMachine(bool isThrowException = false)
    {
        stateDictionary = new();
        voidState = new(isThrowException);
    }

    /// <summary>
    /// StateMachineの有効状態
    /// </summary>
    public bool IsEnable => isEnable;

    /// <summary>
    /// １フレームの更新処理として使用します
    /// </summary>
    public void Update()
    {
        currentState.OnUpdate();

        VerifyNextState();
    }

    /// <summary>
    /// 一定時間の更新処理として使用します
    /// </summary>
    public void FixedUpdate()
    {
        currentState.OnFixedUpdate();

        VerifyNextState();
    }

    /// <summary>
    /// 新しい状態を登録します
    /// </summary>
    /// <param name="key">状態を登録する列挙子</param>
    /// <param name="value">状態のインスタンス</param>
    /// <param name="isOverride">インスタンスをシングルトンにします</param>
    public void Register(TStateEnum key, IState value, bool isOverride = false)
    {
        if (!(stateDictionary.TryAdd(key, value) && isOverride))
        {
            stateDictionary[key] = value;
        }
    }

    /// <summary>
    /// 状態の登録解除をする
    /// </summary>
    /// <param name="key">解除する状態のキー</param>
    /// <param name="isForce">現在状態を実行していても強制的に削除する</param>
    public void Unregister(TStateEnum key, bool isForce = true)
    {
        if (!stateDictionary.ContainsKey(key))
        {
            // 状態が既に存在しなければ無視する
            return;
        }

        if (isForce || stateDictionary[key] != currentState)
        {
            // 強制削除するか状態が別の時は削除する
            stateDictionary.Remove(key);
        }
    }

    /// <summary>
    /// StateMachineを有効化する
    /// </summary>
    /// <param name="initalState">初期の状態</param>
    public void Enable(TStateEnum initalState)
    {
        ChangeState(initalState);

        isEnable = true;
    }

    /// <summary>
    /// StateMachineを無効化します
    /// </summary>
    public void Disable()
    {
        if (isEnable)
        {
            // 終了処理を呼び出して無効化
            currentState.OnExit();
            isEnable = false;

            // 虚無状態を挿入
            currentState = voidState;
        }
    }

    /// <summary>
    /// 現在の状態をstring型で返します
    /// </summary>
    /// <returns></returns>
    public string GetStateString() => currentState.ToString();

    /// <summary>
    /// 状態を更新
    /// </summary>
    /// <param name="state">次に更新する状態</param>
    private void ChangeState(TStateEnum state)
    {
        if (currentState != null)
        {
            // 状態があれば前回の終了処理を呼び出し
            currentState.OnExit();
        }

        // 新しい状態を登録
        currentState = stateDictionary[state];

        currentState.OnEnter();
    }

    private void VerifyNextState()
    {
        if (!isEnable)
        {
            // 無効状態なら次の状態検証をしない
            return;
        }

        TStateEnum receivedNextState = currentState.NextStateComparison<TStateEnum>();

        if (stateDictionary[receivedNextState] != currentState)
        {
            // 受け取った状態が現在の状態と違ったら状態を変更する
            ChangeState(receivedNextState);
        }
    }

    private class VoidState : IState
    {
        private bool isThrowException;
        private Exception ex = new("状態は無効です");

        public VoidState(bool isThrowException)
        {
            this.isThrowException = isThrowException;
        }

        T IState.NextStateComparison<T>()
        {
            throw ex;
        }

        void IState.OnEnter() { ThrowException(); }

        void IState.OnExit() { ThrowException(); }

        void IState.OnFixedUpdate() { ThrowException(); }

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