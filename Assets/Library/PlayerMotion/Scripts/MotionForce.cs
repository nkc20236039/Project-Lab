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
            // 移動方向に応じた速度を取得
            float horizontalSpeed = (0 < keyInput.x) ? left : right;
            float verticalSpeed = (0 < keyInput.z) ? forward : back;
            
            // これまでの結果から前後と横移動を取得
            float forwardMove = Vector3.Dot(keyInput, result);
            Vector3 sideMove = result - forwardMove * result;

            // 前方方向を絶対値化
            forwardMove = Mathf.Abs(forwardMove);

            // 速度を再設定して返す
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