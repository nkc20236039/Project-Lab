using System;
using UnityEngine;
using CharacterMotion.Accessory;

namespace CharacterMotion
{
    public class MotionCreator
    {
        private Rigidbody rigidbody;
        private Rigidbody2D rigidbody2D;
        private float time;
        private Vector3 input;

        internal Rigidbody Rigidbody => rigidbody;
        internal Rigidbody2D Rigidbody2D => rigidbody2D;
        internal float Time
        {
            get => time;
            set => time = value;
        }
        internal Vector3 Input => input;

        public MotionCreator(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
        }

        public MotionCreator(Rigidbody2D rigidbody2D)
        {
            this.rigidbody2D = rigidbody2D;
        }

        // デフォルトコンストラクタ
        public MotionCreator() { }

        public IMotionStandardHandle Create(float input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = new Vector3(input, 0, 0);

            return motionAccessory;
        }

        public IMotionStandardHandle Create(Vector2 input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = new Vector3(input.x, 0, input.y);

            return motionAccessory;
        }

        public IMotionStandardHandle Create(Vector3 input)
        {
            MotionAccessory motionAccessory = new();
            motionAccessory.MotionCreator = this;
            this.input = input;

            return motionAccessory;
        }
    }

    public enum MotionAxis
    {
        None,
        XYZ,
        X, Y, Z,
        XY, XZ, YZ
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

    public interface IMotionForceHandle : IMotionResult
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

    public interface IMotionResult
    {
        /// <summary>
        /// 計算結果を取得します
        /// </summary>
        public Vector3 GetForce();

        /// <summary>
        /// 計算結果をRigidbody.AddForceとして実行します
        /// </summary>
        public void AddForce(ForceMode forceMode);

        public void AddForce(ForceMode2D forceMode);

        /// <summary>
        /// 計算結果をRigidbody.Velocityに設定します
        /// </summary>
        public void SetVelocity();

        /// <summary>
        /// キャラクターの滑らかな回転を計算します
        /// </summary>
        public void CharacterSmoothlyRotation(ref Quaternion currentRotation, float smoothTime, MotionAxis impactAxis);

        /// <summary>
        /// 移動する方向を回転に変換します
        /// </summary>
        public Quaternion CharacterRotation(MotionAxis impactAxis);
    }
}