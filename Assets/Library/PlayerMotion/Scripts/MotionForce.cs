using System.Drawing;
using UnityEngine;

namespace PlayerMotion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
    {
        IMotionForceHandle IMotionForceHandle.OverallSpeed(float speed)
        {
            result *= speed;

            return this;
        }

        // IMotionForceHandle IMotionForceHandle.AdvancedForSpeed(float forward, float back, float left, float right)
        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float left, float right)
        {
            // �ړ������ɉ��������x���擾
            float horizontalSpeed = (0 < keyInput.x) ? left : right;
            float verticalSpeed = (0 < keyInput.z) ? forward : back;
            
            // ����܂ł̌��ʂ���O��Ɖ��ړ����擾
            float forwardMove = Vector3.Dot(keyInput, result);
            Vector3 sideMove = result - forwardMove * result;

            // �O���������Βl��
            forwardMove = Mathf.Abs(forwardMove);

            // ���x���Đݒ肵�ĕԂ�
            result
                = forwardMove * result.normalized * verticalSpeed
                + sideMove.normalized * horizontalSpeed;

            return this;
        }

        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float side)
        {
            AdvancedForSpeed(forward, back, side, side);

            return this;
        }

        IMotionForceHandle IMotionForceHandle.CustomSpeed(Vector3 speed)
        {
            result = Vector3.Scale(result, speed);

            return this;
        }

        public IMotionForceHandle AdditionSpeed(Vector3 speed)
        {
            result += speed;

            return this;
        }
    }
}