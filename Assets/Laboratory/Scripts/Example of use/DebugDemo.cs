using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDemo : DebugWindowVisualizer
{
    protected override void DebugLabels(int id)
    {
        GUILayout.Label("test");

        GUI.DragWindow();
    }
}
