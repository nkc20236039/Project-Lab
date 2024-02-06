using System.Numerics;

namespace UnityExtensions
{
    public struct Convert
    {
        /// <summary>
        /// UnityEngineのベクトルをSystem.Numericsのベクトルに変換します
        /// </summary>
        /// <param name="vector">UnityEngine.Vector2</param>
        /// <returns></returns>
        public static Vector2 ToSystemVector(UnityEngine.Vector2 vector)
            => new Vector2(vector.x, vector.y);

        /// <summary>
        /// System.NumericsのベクトルをUnityEngineのベクトルに変換します
        /// </summary>
        /// <param name="vector">System.Numerics.Vector2</param>
        /// <returns></returns>
        public static UnityEngine.Vector2 ToUnityVector(Vector2 vector)
            => new UnityEngine.Vector2(vector.X, vector.Y);

        /// <summary>
        /// UnityEngine.Vector3をSystem.Numerics.Vector3に変換します
        /// </summary>
        /// <param name="vector">UnityEngine.Vector3</param>
        /// <returns></returns>
        public static Vector3 ToSystemVector(UnityEngine.Vector3 vector)
            => new Vector3(vector.x, vector.y, vector.z);

        /// <summary>
        /// System.Numerics.Vector3をUnityEngine.Vector3に変換します
        /// </summary>
        /// <param name="vector">System.Numerics.Vector3</param>
        /// <returns></returns>
        public static UnityEngine.Vector3 ToUnityVector(Vector3 vector)
            => new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
    }
}