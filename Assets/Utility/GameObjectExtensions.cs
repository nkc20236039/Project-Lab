using System;
using UnityEngine;

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
}
