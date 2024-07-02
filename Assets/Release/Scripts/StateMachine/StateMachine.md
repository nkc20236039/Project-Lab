## 必要ファイル
- `StateMacine.cs`
- `IState.cs`

## 生成
```c#
public StateMachine([bool isThrowException = false]);
```
### 引数
1.  `true`にするとStateMachineが無効状態時の呼び出しに対しエラーが発生するようになります

## public関数
</br>

状態の登録を行います
```c#
public void Register(Enum key, IState value, [bool isOverride = false]);
```
### 引数
1. 状態の管理をするEnumの値
2. 状態のインスタンス
3. `true`の場合、既に同じキーで登録されていた時に新しいインスタンスに上書きします

---
</br>

該当の状態を解除します
```c#
public void Unregister(Enum key, [bool isForce = true]);
```
### 引数
1. 登録解除したいキー
2. `true`の場合、現在対象の状態を実行中であっても強制的に削除します

---
</br>

現在の状態を更新します
```c#
public void Update();
```

---
</br>

StateMachineを有効化します
```c#
public void Enable(Enum initalState);
```

### 引数
1. 有効化するときに最初に実行する状態

---
</br>

StateMachineを無効化します
```c#
public void Disable();
```

---
</br>

現在の状態をString型で取得します
```c#
public string GetStateString();
```

## public変数
現在のStateMachineの有効状態を返します
```
public bool IsEnable { get; }
```