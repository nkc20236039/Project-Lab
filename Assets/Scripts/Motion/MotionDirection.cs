using UnityEngine;

namespace Player.Motion
{
    public partial struct MotionBuilder : IMotionStandardHandle, IMotionDirectionHandle
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


    }
}