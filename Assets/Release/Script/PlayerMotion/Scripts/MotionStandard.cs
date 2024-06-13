using UnityEngine;

namespace CharacterMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
    {
        public IMotionDirectionHandle ObjectView(GameObject targetObject)
        {
            result
                = targetObject.transform.forward * motionCreator.Input.z
                + targetObject.transform.right * motionCreator.Input.x;

            return this;
        }

        IMotionDirectionHandle IMotionStandardHandle.WorldSpace()
        {
            result = motionCreator.Input;

            return this;
        }
    }
}