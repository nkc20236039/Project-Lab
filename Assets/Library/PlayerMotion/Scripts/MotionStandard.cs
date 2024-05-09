using UnityEngine;

namespace PlayerMotion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
    {
        public IMotionDirectionHandle ObjectView(GameObject targetObject)
        {
            result
                = targetObject.transform.forward * keyInput.z
                + targetObject.transform.right * keyInput.x;

            return this;
        }

        IMotionDirectionHandle IMotionStandardHandle.WorldSpace()
        {
            result = keyInput;

            return this;
        }
    }
}