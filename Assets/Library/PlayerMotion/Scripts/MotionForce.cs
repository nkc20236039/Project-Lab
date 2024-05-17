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
            // ˆÚ“®•ûŒü‚É‰ž‚¶‚½‘¬“x‚ðŽæ“¾
            float horizontalSpeed = (0 < moveKey.x) ? left : right;
            float verticalSpeed = (0 < moveKey.z) ? forward : back;

            // ‚±‚ê‚Ü‚Å‚ÌŒ‹‰Ê‚©‚ç‘OŒã‚Æ‰¡ˆÚ“®‚ðŽæ“¾
            float forwardMove = Vector3.Dot(moveKey, result);
            Vector3 sideMove = result - forwardMove * result;

            // ‘¬“x‚ðÄÝ’è‚µ‚Ä•Ô‚·
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