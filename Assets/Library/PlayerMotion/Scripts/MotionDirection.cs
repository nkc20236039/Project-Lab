using UnityEngine;

namespace PlayerMotion
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

        IMotionDirectionHandle IMotionDirectionHandle.Inversion(MotionAxis axis)
        {
            Vector3 inversionVector;
            inversionVector = axis switch
            {
                MotionAxis.XYZ => new Vector3(-1, -1, -1),
                MotionAxis.X => new Vector3(-1, 1, 1),
                MotionAxis.Y => new Vector3(1, -1, 1),
                MotionAxis.Z => new Vector3(1, 1, -1),
                MotionAxis.XY => new Vector3(-1, -1, 1),
                MotionAxis.XZ => new Vector3(-1, 1, -1),
                MotionAxis.YZ => new Vector3(1, -1, -1),
                _ => new Vector3(1, 1, 1)
            };

            result = Vector3.Scale(result, inversionVector);

            return this;
        }
    }
}