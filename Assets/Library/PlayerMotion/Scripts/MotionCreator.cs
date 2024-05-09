using System;
using UnityEngine;

namespace PlayerMotion
{
    public class MotionCreator
    {
        public IMotionStandardHandle Create(float input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = new Vector3(input, 0, 0);

            return motionBuilder;
        }

        public IMotionStandardHandle Create(Vector2 input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = new Vector3(input.x, 0, input.y);

            return motionBuilder;
        }

        public IMotionStandardHandle Create(Vector3 input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = input;

            return motionBuilder;
        }
    }

    public enum MotionAxis
    {
        XYZ,
        X, Y, Z,
        XY, XZ,
        YZ,
    }

    public interface IMotionStandardHandle
    {
        /// <summary>
        /// �ʏ�̍��W�����g�p���܂�
        /// </summary>
        public IMotionDirectionHandle WorldSpace();

        /// <summary>
        /// ����̃I�u�W�F�N�g�̌����ɍ��킹�đO�������肵�܂�
        /// </summary>
        /// <param name="targetObject"></param>
        public IMotionDirectionHandle ObjectView(GameObject camera);
    }

    public interface IMotionDirectionHandle : IMotionForceHandle
    {
        /// <summary>
        /// �����ʂł̈ړ��ɏC�����܂�
        /// </summary>
        public IMotionDirectionHandle PlaneMotion();

        /// <summary>
        /// �@���ɏ]�����ړ������ɏC�����܂�
        /// </summary>
        /// <param name="normal">�]�킹��@��</param>
        public IMotionDirectionHandle ProjectOnPlane(Vector3 normal);

        public IMotionDirectionHandle Inversion(MotionAxis axis);
    }

    public interface IMotionForceHandle : IMotionGettable
    {
        /// <summary>
        /// �S�Ă̕����ɋϓ��ɑ��x����Z���܂�
        /// </summary>
        /// <param name="speed">���x</param>
        public IMotionForceHandle OverallSpeed(float speed);

        /// <summary>
        /// ���ꂼ��̕����Ɏw�肵�����x����Z���܂�
        /// </summary>
        /// <param name="forward">�O���̑��x</param>
        /// <param name="back">����̑��x</param>
        /// <param name="left">�����̑��x</param>
        /// <param name="right">�E���̑��x</param>
        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float left, float right);

        /// <summary>
        /// ���ꂼ��̕����Ɏw�肵�����x����Z���܂�
        /// </summary>
        /// <param name="forward">�O���̑��x</param>
        /// <param name="back">����̑��x</param>
        /// <param name="side">�������̑��x</param>
        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float side);

        /// <summary>
        /// ���ꂼ��̃x�N�g���ɑ��x����Z���܂�
        /// </summary>
        /// <param name="speed">���x</param>
        public IMotionForceHandle CustomSpeed(Vector3 speed);

        /// <summary>
        /// ���ꂼ��̃x�N�g���ɑ��x�����Z���܂�
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotionForceHandle AdditionSpeed(Vector3 speed);
    }

    public interface IMotionGettable
    {
        /// <summary>
        /// �͂̌v�Z����
        /// </summary>
        public Vector3 ForceVector { get; }

        /// <summary>
        /// Time.DeltaTime����Z�����͂̌v�Z����
        /// </summary>
        public Vector3 DeltaTimeForce { get; }

        /// <summary>
        /// �͂̑傫��
        /// </summary>
        public float ForceMagnitude { get; }

        /// <summary>
        /// �͂̕���
        /// </summary>
        public Vector3 ForceNormal { get; }
    }
}