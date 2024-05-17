using UnityEngine;

namespace PlayerMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
    {
        public IMotionDirectionHandle ObjectView(GameObject targetObject)
        {
            result
                = targetObject.transform.forward * moveKey.z
                + targetObject.transform.right * moveKey.x;

            return this;
        }

        IMotionDirectionHandle IMotionStandardHandle.WorldSpace()
        {
            result = moveKey;

            return this;
        }
    }
}