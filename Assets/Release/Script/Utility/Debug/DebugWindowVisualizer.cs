using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public abstract class DebugWindowVisualizer : MonoBehaviour
{
    private static int windowID = 0;
    private int originalWindowID = 0;

    [Header("デバッグ項目")]
    [SerializeField]
    private string windowName;
    [SerializeField]
    private Rect windowRect = new(0f, 0f, 200, 300);
    [SerializeField]
    private int titleSize;
    [SerializeField]
    private bool isForce;

    private bool isHoge = true;

    protected virtual void OnGUI()
    {
        // タイトルの大きさを変更
        GUIStyle guiStyle = GUI.skin.window;
        guiStyle.fontSize = titleSize;

        // 表示する命令か強制表示をする場合
        if (Selection.activeGameObject == gameObject || isForce)
        {
            windowRect = GUILayout.Window(originalWindowID, windowRect, DebugLabels, windowName, guiStyle);
        }
    }

    /// <summary>
    /// GUIWindowに表示する項目を設定する
    /// </summary>
    /// <param name="id"></param>
    protected abstract void DebugLabels(int id);

    /// <summary>
    /// これを呼び出すと個別のウィンドウとして管理します
    /// </summary>
    protected void IndividualWindow()
    {
        if (originalWindowID == 0)
        {
            windowID++;
            originalWindowID = windowID;
        }
    }
}