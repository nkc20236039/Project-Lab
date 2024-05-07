using System.Drawing;
using UnityEngine;

namespace Player.Motion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
    {
        IMotionForceHandle IMotionForceHandle.OverallSpeed(float speed)
        {
            result *= speed;

            return this;
        }

        IMotionForceHandle IMotionForceHandle.AdvancedForSpeed(float forward, float back, float left, float right)
        {
            result = AdvancedForSpeed(forward, back, left, right);

            return this;
        }

        IMotionForceHandle IMotionForceHandle.AdvancedForSpeed(float forward, float back, float side)
        {
            result = AdvancedForSpeed(forward, back, side, side);
            
            return this;
        }

        IMotionForceHandle IMotionForceHandle.CustomSpeed(Vector3 speed)
        {
            result = Vector3.Scale(result, speed);

            return this;
        }

        private Vector3 AdvancedForSpeed(float forward, float back, float left, float right)
        {
            // 移動方向に応じた速度を取得
            float horizontalSpeed = (0 < keyInput.x) ? left : right;
            float verticalSpeed = (0 < keyInput.z) ? forward : back;

            // これまでの結果から前後と横移動を取得
            Vector3 forwardMove = Vector3.Project(keyInput, result);
            Vector3 sideMove = result - forwardMove;

            // 速度を再設定して返す
            return forwardMove.normalized * verticalSpeed + sideMove.normalized * horizontalSpeed;
        }
    }
}