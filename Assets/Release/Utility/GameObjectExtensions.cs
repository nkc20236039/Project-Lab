using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameObjectExtensions
{
    /// <summary>
    /// レイヤーが一致しているか調べます
    /// </summary>
    /// <param name="layer">対象のレイヤー</param>
    /// <param name="layerMask">比較するレイヤーマスク</param>
    /// <returns></returns>
    public static bool IsLayersMatch(this GameObject gameObject, LayerMask layerMask)
    {
        // layerMaskがEverything(-1)ならtrueにする
        if ((int)layerMask == -1)
        {
            return true;
        }

        // layerを二進数に変換
        string bitString = Convert.ToString((int)layerMask, 2);
        int bit = 0;

        try
        {
            // string型のbitをintに変換
            bit = int.Parse(bitString);
        }
        catch
        {
            // 変換できなければfalseを返す
            return false;
        }

        // bitとレイヤーの番号分シフトした数をand演算
        int matchBit = bit & 1 << gameObject.layer;

        // どこかに1があれば一致しているのでtrueを返し、なければfalse
        return matchBit != 0;
    }

    // TODO: sceneのEnum化
    // TODO: SceneManager.LoadScene()でEnumを使うオーバーロード

    /// <summary>
    /// rootオブジェクトのTransformの取得を試みます
    /// </summary>
    public static Transform TryGetRoot(this Transform child)
    {
        if (child.parent == null)
        {
            return child;
        }

        return child.root;
    }

    public static Transform[] GetChildren(this Transform parent)
    {
        Transform[] children = new Transform[parent.childCount];

        for (int i = 0; i < children.Length; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }

    public static Transform[] GetIgnoreParentFamily(this Transform parent)
    {
        Transform[] family = parent.GetComponentsInChildren<Transform>(true);

        Transform[] ignoreParentFamily = new Transform[family.Length - 1];

        Array.Copy(family, 1, ignoreParentFamily, 0, ignoreParentFamily.Length);

        return ignoreParentFamily;
    }
}