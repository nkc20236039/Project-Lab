using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    public Transform target; // 敵キャラクターのTransform
    public Transform turretBase; // 砲台の基部のTransform
    public Transform turretBarrel; // 砲台の砲身のTransform

    void Update()
    {
        if (target != null)
        {
            // 砲台から目標への方向ベクトルを計算
            Vector3 directionToTarget = target.position - turretBase.position;

            // 水平回転（方位角）の計算と適用
            float azimuth = Mathf.Atan2(directionToTarget.z, directionToTarget.x) * Mathf.Rad2Deg;
            turretBase.rotation = Quaternion.Euler(0, azimuth, 0);

            // 垂直回転（仰角）の計算と適用
            float horizontalDistance = new Vector2(directionToTarget.x, directionToTarget.z).magnitude;
            float elevation = Mathf.Atan2(directionToTarget.y, horizontalDistance) * Mathf.Rad2Deg;
            turretBarrel.localRotation = Quaternion.Euler(-elevation, 0, 0);

            // デバッグ用：コンソールに角度を出力
            Debug.Log($"方位角: {azimuth}度, 仰角: {elevation}度");
        }
    }
}