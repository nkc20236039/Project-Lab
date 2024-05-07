using UnityEngine;

namespace Player.Motion
{
    public class MotionCreator
    {
        public IMotionStandardHandle Create(float input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = new Vector3(input, 0, 0);

            return motionBuilder;
        }

        public IMotionStandardHandle Create(Vector2 input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = new Vector3(input.x, 0, input.y);

            return motionBuilder;
        }

        public IMotionStandardHandle Create(Vector3 input)
        {
            MotionBuilder motionBuilder = new();
            motionBuilder.InitalInput = input;

            return motionBuilder;
        }
    }

    public interface IMotionStandardHandle
    {
        public IMotionDirectionHandle WorldSpace();

        public IMotionDirectionHandle CameraView(GameObject camera);
    }

    public interface IMotionDirectionHandle : IMotionForceHandle
    {
        public IMotionDirectionHandle PlaneMotion();

        public IMotionDirectionHandle ProjectOnPlane(Vector3 normal);
    }

    public interface IMotionForceHandle : IMotionGettable
    {
        public IMotionForceHandle OverallSpeed(float speed);

        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float left, float right);

        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float side);

        public IMotionForceHandle CustomSpeed(Vector3 speed);
    }

    public interface IMotionGettable
    {
        public Vector3 ForceVector { get; }
        public Vector3 DeltaTimeForce { get; }
        public float ForceMagnitude { get; }
        public Vector3 ForceNormal { get; }
    }
}