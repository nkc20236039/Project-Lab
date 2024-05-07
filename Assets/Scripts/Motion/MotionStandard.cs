using UnityEngine;

namespace Player.Motion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
    {
        public IMotionDirectionHandle CameraView(GameObject camera)
        {
            result
                = camera.transform.forward * keyInput.z
                + camera.transform.right * keyInput.x;

            return this;
        }

        IMotionDirectionHandle IMotionStandardHandle.WorldSpace()
        {
            result = keyInput;

            return this;
        }
    }
}