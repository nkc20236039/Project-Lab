using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public abstract class DebugWindowVisualizer : MonoBehaviour
{
    private static int windowID = 0;
    private int originalWindowID = 0;

    [Header("�f�o�b�O����")]
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
        // �^�C�g���̑傫����ύX
        GUIStyle guiStyle = GUI.skin.window;
        guiStyle.fontSize = titleSize;

        // �\�����閽�߂������\��������ꍇ
        if (Selection.activeGameObject == gameObject || isForce)
        {
            windowRect = GUILayout.Window(originalWindowID, windowRect, DebugLabels, windowName, guiStyle);
        }
    }

    /// <summary>
    /// GUIWindow�ɕ\�����鍀�ڂ�ݒ肷��
    /// </summary>
    /// <param name="id"></param>
    protected abstract void DebugLabels(int id);

    /// <summary>
    /// ������Ăяo���ƌʂ̃E�B���h�E�Ƃ��ĊǗ����܂�
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