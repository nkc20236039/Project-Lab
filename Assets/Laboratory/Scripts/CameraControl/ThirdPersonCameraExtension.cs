using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraExtension : CinemachineExtension
{
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        /* -------------------------------------------------------------------------
         * CinemachineVirtualCameraBase vcam・・・対象バーチャルカメラ
         * CinemachineCore.Stage stage・・・・・・・実行タイミング(Body, Aim, Noise)
         * ref CameraState state・・・・・・・・・・・カメラ状態のデータ。これを編集して適用する
         * float deltaTime・・・・・・・・・・・・・・・現在のデルタタイム
         ------------------------------------------------------------------------- */




    }
}
