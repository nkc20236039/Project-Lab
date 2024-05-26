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
    private bool isForce;

    protected virtual void OnGUI()
    {
        // �\�����閽�߂������\��������ꍇ
        if (Selection.activeGameObject == gameObject || isForce)
        {
            GUILayout.Window(originalWindowID, windowRect, DebugLabels, windowName);
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