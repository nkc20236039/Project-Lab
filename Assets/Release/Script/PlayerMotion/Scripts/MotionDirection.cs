using UnityEngine;

namespace CharacterMotion.Accessory
{
    public partial struct MotionAccessory : IMotionStandardHandle, IMotionDirectionHandle
    {
        IMotionDirectionHandle IMotionDirectionHandle.PlaneMotion()
        {
            result = Vector3.Scale(result, new Vector3(1, 0, 1)).normalized;

            return this;
        }

        IMotionDirectionHandle IMotionDirectionHandle.ProjectOnPlane(Vector3 normal)
        {
            result = Vector3.ProjectOnPlane(result, normal);

            return this;
        }

        IMotionDirectionHandle IMotionDirectionHandle.Inversion(MotionAxis axis)
        {
            // 反転する軸にマイナスを掛ける
            Vector3 inversionVector = AxisVector(axis, -1, 1);
            result = Vector3.Scale(result, inversionVector);

            return this;
        }
    }
}