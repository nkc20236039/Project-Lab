using System.Drawing;
using UnityEngine;

namespace PlayerMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
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
            float horizontalSpeed = (0 < moveKey.x) ? left : right;
            float verticalSpeed = (0 < moveKey.z) ? forward : back;

            // ����܂ł̌��ʂ���O��Ɖ��ړ����擾
            float forwardMove = Vector3.Dot(moveKey, result);
            Vector3 sideMove = result - forwardMove * result;

            // ���x���Đݒ肵�ĕԂ�
            result
                = result.normalized * verticalSpeed
                + sideMove.normalized * horizontalSpeed;

            return this;
        }

        IMotionForceHandle IMotionForceHandle.AdvancedForSpeed(float forward, float back, float side)
        {
            AdvancedForSpeed(forward, back, side, side);

            return this;
        }

        IMotionForceHandle IMotionForceHandle.CustomSpeed(Vector3 speed)
        {
            result = Vector3.Scale(result, speed);

            return this;
        }

        IMotionForceHandle IMotionForceHandle.AdditionSpeed(Vector3 speed)
        {
            result += speed;

            return this;
        }
    }
}