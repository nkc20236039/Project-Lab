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
         * CinemachineVirtualCameraBase vcam�E�E�E�Ώۃo�[�`�����J����
         * CinemachineCore.Stage stage�E�E�E�E�E�E�E���s�^�C�~���O(Body, Aim, Noise)
         * ref CameraState state�E�E�E�E�E�E�E�E�E�E�E�J������Ԃ̃f�[�^�B�����ҏW���ēK�p����
         * float deltaTime�E�E�E�E�E�E�E�E�E�E�E�E�E�E�E���݂̃f���^�^�C��
         ------------------------------------------------------------------------- */




    }
}
