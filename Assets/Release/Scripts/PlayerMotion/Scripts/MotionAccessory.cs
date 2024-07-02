using UnityEngine;
using System;

namespace CharacterMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
    {
        private Vector3 result;
        private MotionCreator motionCreator;

        internal MotionCreator MotionCreator
        {
            set => motionCreator = value;
        }

        Vector3 IMotionResult.GetForce()
        {
            return result;
        }

        void IMotionResult.AddForce(ForceMode forceMode)
        {
            motionCreator.Rigidbody.AddForce(result, forceMode);
        }

        void IMotionResult.AddForce(ForceMode2D forceMode)
        {
            motionCreator.Rigidbody2D.AddForce(result, forceMode);
        }

        void IMotionResult.SetVelocity()
        {
            motionCreator.Rigidbody.velocity = result;
        }

        void IMotionResult.CharacterSmoothlyRotation(ref Quaternion currentRotation, float smoothTime, MotionAxis impactAxis)
        {
            Vector3 moveTemp = Vector3.Scale(result.normalized, AxisVector(impactAxis, 1, 0));

            if (moveTemp.magnitude != 0)
            {
                // ˆÚ“®‚µ‚Ä‚¢‚éê‡‚Í‰ñ“]‚ðŠŠ‚ç‚©‚É‚Å‚«‚é
                Quaternion lookRotation = Quaternion.LookRotation(moveTemp);

                currentRotation = Quaternion.Lerp(lookRotation, currentRotation, smoothTime);
            }
        }

        Quaternion IMotionResult.CharacterRotation(MotionAxis impactAxis)
        {
            Vector3 moveTemp = Vector3.Scale(result.normalized, AxisVector(impactAxis, 1, 0));

            Quaternion lookRotation = Quaternion.identity;
            if (moveTemp.magnitude != 0)
            {
                // ˆÚ“®‚µ‚Ä‚¢‚éê‡‚Í‰ñ“]‚ðŠŠ‚ç‚©‚É‚Å‚«‚é
                lookRotation = Quaternion.LookRotation(moveTemp);
            }
            return lookRotation;
        }

        private Vector3 AxisVector(MotionAxis axis, float positive, float negative)
        {
            return axis switch
            {
                MotionAxis.None => new Vector3(negative, negative, negative),
                MotionAxis.XYZ => new Vector3(positive, positive, positive),
                MotionAxis.X => new Vector3(positive, negative, negative),
                MotionAxis.Y => new Vector3(negative, positive, negative),
                MotionAxis.Z => new Vector3(negative, negative, positive),
                MotionAxis.XY => new Vector3(positive, positive, negative),
                MotionAxis.XZ => new Vector3(positive, negative, positive),
                MotionAxis.YZ => new Vector3(negative, positive, positive),
                _ => new Vector3(negative, negative, negative)
            };
        }
    }
}