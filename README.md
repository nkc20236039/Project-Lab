# .gitignoreの記述方法
[.gitignore](https://github.com/nkc20236039/Project-Lab/blob/main/.gitignore)に詳細を記載

# 複数のプロジェクトで使える機能
プロジェクトの最初に入れておけば簡単に使える機能をまとめてある

## SingletonMonoBehaviour
> 備忘録

SingletonMonoBehaviourクラスを継承させることでオブジェクトをシングルトンで管理できるようになる
Awakeをoverrideする場合はbaseを呼び出すこと
ジェネリック引数にシングルトンにしたいクラスを指定

## StateMachineLocator
ステートマシーンのインスタンス登録のためのサービスロケーター
使いたい場所でStateMachineLocatorのインスタンスを生成する必要があるがそれぞれのステートマシーンの中でのみ使用するように限定できる
```c#
// インスタンスの生成
enum PlayerState{
    Idle, Move,
}

StateMachineLocator<PlayerState> stateMachine = new();
```
インスタンスの登録はRegisterメソッドを使用
```c#
public void Register(TState state, IState instance, bool overwrite = false)
```
引数
1. 登録したい状態のEnum
2. 登録したい状態のインスタンス
3. 既に状態が存在した場合、上書きするか(デフォルトはfalse)

インスタンスの取得はGetメソッドを使用
```C#
public IState Get(TState state)
```
引数
1. 取得したい状態のEnum

戻り値
- 引数で指定した状態のインスタンス
