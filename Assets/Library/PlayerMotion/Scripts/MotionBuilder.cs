using UnityEngine;

namespace PlayerMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
    {
        private Vector3 moveKey;
        private Vector3 result;

        internal Vector3 MoveKey
        {
            set => moveKey = value.normalized;
        }

        public Vector3 ForceVector => result;

        public Vector3 DeltaTimeForce => result * Time.deltaTime;

        public float ForceMagnitude => result.magnitude;

        public Vector3 ForceNormal => result.normalized;

        Quaternion IMotionGettable.CharacterRotation(Quaternion currentRotation, float smoothing)
        {
            Vector3 planeMove = new Vector3(result.x, 0, result.z).normalized;

            Quaternion rotation = currentRotation;
            if (planeMove.magnitude != 0)
            {
                // ˆÚ“®‚µ‚Ä‚¢‚éê‡‚Í‰ñ“]‚ðŠŠ‚ç‚©‚É‚Å‚«‚é
                Quaternion lookRotation = Quaternion.LookRotation(planeMove);
                rotation = Quaternion.Lerp(lookRotation, currentRotation, smoothing);
            }

            return rotation;
        }

        private Vector3 AxisVector(MotionAxis axis, float enableVector, float disableVector)
        {
            return axis switch
            {
                MotionAxis.None => new Vector3(disableVector, disableVector, disableVector),
                MotionAxis.XYZ => new Vector3(enableVector, enableVector, enableVector),
                MotionAxis.X => new Vector3(enableVector, disableVector, disableVector),
                MotionAxis.Y => new Vector3(disableVector, enableVector, disableVector),
                MotionAxis.Z => new Vector3(disableVector, disableVector, enableVector),
                MotionAxis.XY => new Vector3(enableVector, enableVector, disableVector),
                MotionAxis.XZ => new Vector3(enableVector, disableVector, enableVector),
                MotionAxis.YZ => new Vector3(disableVector, enableVector, enableVector),
                _ => new Vector3(disableVector, disableVector, disableVector)
            };
        }
    }
}