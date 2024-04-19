# 複数のプロジェクトで使える機能
プロジェクトの最初に入れておけば簡単に使える機能をまとめてある

## SingletonMonoBehaviour
<details>
SingletonMonoBehaviourクラスを継承させることでオブジェクトをシングルトンで管理できるようになる
Awakeをoverrideする場合はbaseを呼び出すこと
ジェネリック引数にシングルトンにしたいクラスを指定
</details>

## StateMachine
<details>
汎用型StateMachineクラス

```c#
public StateMachine(bool isThrowException = false);
```
引数をtrueにすると無効状態時の呼び出しでエラーを投げるようになる

- ## CurrentState
```
public IState CurrentState;
```
現在の状態を取得する

- ## IsEnable
```
public bool IsEnable;
```
StateMachineが有効常態か取得する

- ## Register
```c#
public void Register(Enum key, IState value, bool isSingleton = false);
```
状態の登録を行うクラス。
<details>
<summary>引数</summary>
1. 状態と関連付ける列挙型のキー(enum)
2. IStateを実装した状態のインスタンス(IState)
3. 状態を上書きするか(bool)  デフォルトでfalse
</details>

- ## Enable
```c#
public void Enable(Enum initalState);
```
StateMachineを有効にする
<details>
<summary>引数</summary>
1. 有効にするときの初期状態(enum)
</details>

- ## Disable
```c#
public void Disable();
```
StateMachineを無効にする

- ## Disable
```c#
void IDisposable.Dispose();
```
全ての状態、インスタンスを無効化します

- ## GetStateString
```c#
public string GetStateString()
```
現在の状態をstring型で返す(デバッグ用)

</details>