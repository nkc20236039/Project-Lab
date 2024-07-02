using System;
using UnityEngine;
using CharacterMotion.Accessory;

namespace CharacterMotion
{
    public class MotionCreator
    {
        private Rigidbody rigidbody;
        private Rigidbody2D rigidbody2D;
        private float time;
        private Vector3 input;

        internal Rigidbody Rigidbody => rigidbody;
        internal Rigidbody2D Rigidbody2D => rigidbody2D;
        internal float Time
        {
            get => time;
            set => time = value;
        }
        internal Vector3 Input => input;

        public MotionCreator(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
        }

        public MotionCreator(Rigidbody2D rigidbody2D)
        {
            this.rigidbody2D = rigidbody2D;
        }

        // �f�t�H���g�R���X�g���N�^
        public MotionCreator() { }

        public IMotionStandardHandle Create(float input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = new Vector3(input, 0, 0);

            return motionAccessory;
        }

        public IMotionStandardHandle Create(Vector2 input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = new Vector3(input.x, 0, input.y);

            return motionAccessory;
        }

        public IMotionStandardHandle Create(Vector3 input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = input;

            return motionAccessory;
        }
    }

    public enum MotionAxis
    {
        None,
        XYZ,
        X, Y, Z,
        XY, XZ, YZ
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

    public interface IMotionForceHandle : IMotionResult
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

    public interface IMotionResult
    {
        /// <summary>
        /// �v�Z���ʂ��擾���܂�
        /// </summary>
        public Vector3 GetForce();

        /// <summary>
        /// �v�Z���ʂ�Rigidbody.AddForce�Ƃ��Ď��s���܂�
        /// </summary>
        public void AddForce(ForceMode forceMode);

        public void AddForce(ForceMode2D forceMode);

        /// <summary>
        /// �v�Z���ʂ�Rigidbody.Velocity�ɐݒ肵�܂�
        /// </summary>
        public void SetVelocity();

        /// <summary>
        /// �L�����N�^�[�̊��炩�ȉ�]���v�Z���܂�
        /// </summary>
        public void CharacterSmoothlyRotation(ref Quaternion currentRotation, float smoothTime, MotionAxis impactAxis);

        /// <summary>
        /// �ړ������������]�ɕϊ����܂�
        /// </summary>
        public Quaternion CharacterRotation(MotionAxis impactAxis);
    }
}