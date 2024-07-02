# このプロジェクトでのコーディング規則
不明な点、疑問に思ったことがあればすぐに相談すること

## 命名規則
- privateで宣言する変数は小文字から始まり、単語の間は大文字で区切る  
`hogeFuga`

- メソッド名、クラス名、構造体名、列挙型名はアクセス修飾子に関わらず大文字から始まり、単語の間も大文字で区切る  
`HogeMethod`、`HogeClass`、`HogeStruct`、`HogeEnum`

- 定数は全て大文字で単語の区切りにアンダースコア'_'を使う  
`HOGE_FUGA`

- bool型を返す変数やメソッドには`is/has/can`を使用すること(以下「bool命名規則」)  
`isGround`、`hasItem`、`canSwim`

- 何かの実行を試みる場合には最初に`Try`をつける  
`TryAddItem`

- bool型の命名時、否定する単語を入れない  
×`isNotDead`

- Abstractクラスは最初に`Abstract`をつける  
`AbstractHoge`

- (Abstractではない)基底クラスは最後に`Base`をつけるほうがよい  
`HogeBase`

- インターフェースには最初に`I`をつけること  
`IHoge`

- インターフェースは状況に応じて(動詞を表す言葉なら)`~可能な`の形の英語にする  
`IMovable`

- Unityに存在する命名は極力避ける  
`rigidbody`→`playerRigidbody`

- クラス名と同じ名前のpublic変数は**命名しない**  
×`public Hoge Hoge { get; }`

- `Test`と`Demo`の使い分け  
    - 試しで行う目的で、完成時には不要となる物の命名には`Demo`を使用する

    - 何かを調べたり完成時にも検証として使用する物の命名には`Test`を使用する

`public class DemoPlayer`   仮のプレイヤーという解釈  
`public class TestPlayer`   プレイヤーの検証をする解釈  

## 記述
- namespaceを記述する

- public変数は必ずカプセル化した記述をする  
`public HogeClass Hoge { get; set; }`

- 命名にて、最初に`Try`を記述したメソッドでは戻り値は必ず`bool`か実行した結果の値の型とする

- 関わりの深いinterfaceは同じファイルに**まとめてもよい**

- interfaceは理由が無い限り明示的な実装をする  
`void IHoge.Method() { }`

- 副作用のあるコードの記述を避ける

## 改行
- 計算式が長くなる場合、改行は**記号の前**で行う
``` c#
// 例
float hoge
    = Mathf.Abs(huga)
    * Mathf.Sign(Piyo);
```
- メソッド呼び出しなどで丸括弧`()`の中の記述が重要な場合、**コンマの後**に改行する  
※コンストラクタやメソッドの引数の時は改行しない
``` c#
// 例
Function
(
    hoge1,
    hoge2,
    hoge3,
    hoge4
)

void Function(hoge1, hoge2, hoge3, hoge4)
```

## 条件式規則
- 早期リターンを徹底する
- 条件式が長くなる場合は改行するのではなく新しい変数を宣言する
``` c#
// 例
if(abc == ABC && def <= DEF || ghi != GHI)
{
    
}

bool isAbc = abc == ABC;
bool isDef = def <= DEF;
bool isGhi = ghi != GHI;
if(isAbc && isDef || isGhi)
{

}
```
- bool命名規則に従っている場合は`== true`を省略し、`== false`は`!`を**使用する**方法で記述する
- bool命名規則に従えない場合やライブラリの変数などでbool命名規則でないものは`== true`や`== false`を**省略せずに**記述する
- Unityのnullは条件演算子を省略できるが**しないようにする**


# フォルダ階層での規則
## プロジェクト
<details>
<summary>Assets</summary>

外部アセットなどを入れる  
※以下に書かれていないフォルダはコミット時に除外される
- **Editor**  
UnityのEditorフォルダ
- **Projects**  
今回のプロジェクトに必要なフォルダを扱うフォルダ
    - **Animations**  
アニメーション関連フォルダ
        - **Animation Controller**  
アニメーションコントローラーを扱うフォルダ
        - **Animations**  
アニメーションコントローラーを扱うフォルダ
        - **Fonts**  
フォントを扱うフォルダ
    - **Graphics**  
ビジュアル部分をまとめるフォルダ
        - **Materials**  
マテリアルを扱うフォルダ
        - **Models**  
CGモデルを扱うフォルダ
        - **Shaders**  
シェーダーを扱うフォルダ
        - **Sprites**  
イラストイメージ、スプライトを扱うフォルダ
        - **Textures**  
テクスチャを扱うフォルダ
    - **Prefabs**  
プレハブを扱うフォルダ
    - **Scenes**  
シーンを扱うフォルダ
        - **Demo Scenes**  
本ゲームでは使用しないテスト用のシーンを管理するフォルダ
        - **Main Scenes**  
本ゲームで使用するシーンを管理するフォルダ
    - **Scriptable Objects**  
ScriptableObjectを扱うフォルダ
        - **Data**  
データアセットを扱うフォルダ
        - **Scripts**  
データアセットを生成するスクリプトを扱うフォルダ
    - **Scripts**  
スクリプトを扱うフォルダ
    - **Sounds**  
サウンドをまとめるフォルダ
        - **BGM**  
BGMを扱うフォルダ
        - **SoundEffects**  
効果音を扱うフォルダ
- **Resources**  
UnityのResourcesフォルダ

</details>

## ヒエラルキー
<details>
<summary>Scene</summary>

- **Camera**  
SceneカメラやCinemachineを配置
- **Environment**  
ライティングや環境設定に関するオブジェクトを配置
- **System**  
System系のコンポーネントやスクリプトをアタッチした空オブジェクトを配置する  
基本的に原点固定のオブジェクト
- **UI**  
GUI系のオブジェクトを配置
- **Static Object**  
移動することのないメッシュオブジェクトを配置
- **Dynamic Object**  
移動するメッシュオブジェクトを配置
</details>
