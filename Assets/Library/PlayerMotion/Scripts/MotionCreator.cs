using System;
using UnityEngine;

namespace PlayerMotion
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

    public enum MotionAxis
    {
        XYZ,
        X, Y, Z,
        XY, XZ,
        YZ,
    }

    public interface IMotionStandardHandle
    {
        /// <summary>
        /// 通常の座標軸を使用します
        /// </summary>
        public IMotionDirectionHandle WorldSpace();

        /// <summary>
        /// 特定のオブジェクトの向きに合わせて前方を決定します
        /// </summary>
        /// <param name="targetObject"></param>
        public IMotionDirectionHandle ObjectView(GameObject camera);
    }

    public interface IMotionDirectionHandle : IMotionForceHandle
    {
        /// <summary>
        /// 水平面での移動に修正します
        /// </summary>
        public IMotionDirectionHandle PlaneMotion();

        /// <summary>
        /// 法線に従った移動方向に修正します
        /// </summary>
        /// <param name="normal">従わせる法線</param>
        public IMotionDirectionHandle ProjectOnPlane(Vector3 normal);

        public IMotionDirectionHandle Inversion(MotionAxis axis);
    }

    public interface IMotionForceHandle : IMotionGettable
    {
        /// <summary>
        /// 全ての方向に均等に速度を乗算します
        /// </summary>
        /// <param name="speed">速度</param>
        public IMotionForceHandle OverallSpeed(float speed);

        /// <summary>
        /// それぞれの方向に指定した速度を乗算します
        /// </summary>
        /// <param name="forward">前方の速度</param>
        /// <param name="back">後方の速度</param>
        /// <param name="left">左方の速度</param>
        /// <param name="right">右方の速度</param>
        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float left, float right);

        /// <summary>
        /// それぞれの方向に指定した速度を乗算します
        /// </summary>
        /// <param name="forward">前方の速度</param>
        /// <param name="back">後方の速度</param>
        /// <param name="side">横方向の速度</param>
        public IMotionForceHandle AdvancedForSpeed(float forward, float back, float side);

        /// <summary>
        /// それぞれのベクトルに速度を乗算します
        /// </summary>
        /// <param name="speed">速度</param>
        public IMotionForceHandle CustomSpeed(Vector3 speed);

        /// <summary>
        /// それぞれのベクトルに速度を加算します
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotionForceHandle AdditionSpeed(Vector3 speed);
    }

    public interface IMotionGettable
    {
        /// <summary>
        /// 力の計算結果
        /// </summary>
        public Vector3 ForceVector { get; }

        /// <summary>
        /// Time.DeltaTimeを乗算した力の計算結果
        /// </summary>
        public Vector3 DeltaTimeForce { get; }

        /// <summary>
        /// 力の大きさ
        /// </summary>
        public float ForceMagnitude { get; }

        /// <summary>
        /// 力の方向
        /// </summary>
        public Vector3 ForceNormal { get; }
    }
}