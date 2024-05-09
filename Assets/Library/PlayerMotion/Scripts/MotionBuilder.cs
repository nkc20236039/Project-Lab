using UnityEngine;

namespace PlayerMotion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
    {
        private Vector3 keyInput;
        private Vector3 result;

        internal MotionBuilder(Vector3 keyInput, Vector3 result)
        {
            this.keyInput = keyInput;
            this.result = result;
        }

        public Vector3 InitalInput
        {
            get => keyInput;
            set => keyInput = value.normalized;
        }

        public Vector3 ForceVector => result;

        public Vector3 DeltaTimeForce => result * Time.deltaTime;

        public float ForceMagnitude => result.magnitude;

        public Vector3 ForceNormal => result.normalized;
    }
}