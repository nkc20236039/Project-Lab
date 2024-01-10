[!WARNING]
このリポジトリのREADMEは備忘録を含みます


# .gitignoreの記述方法
[.gitignore](https://github.com/nkc20236039/Project-Lab/blob/main/.gitignore)に詳細を記載

# 複数のプロジェクトで使える機能
プロジェクトの最初に入れておけば簡単に使える機能をまとめてある

## SingletonMonoBehaviour
SingletonMonoBehaviourクラスを継承させることでオブジェクトをシングルトンで管理できるようになる
Awakeをoverrideする場合はbaseを呼び出すこと
ジェネリック引数にシングルトンにしたいクラスを指定
