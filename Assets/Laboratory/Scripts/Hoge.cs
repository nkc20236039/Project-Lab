using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    public Transform target; // �G�L�����N�^�[��Transform
    public Transform turretBase; // �C��̊��Transform
    public Transform turretBarrel; // �C��̖C�g��Transform

    void Update()
    {
        if (target != null)
        {
            // �C�䂩��ڕW�ւ̕����x�N�g�����v�Z
            Vector3 directionToTarget = target.position - turretBase.position;

            // ������]�i���ʊp�j�̌v�Z�ƓK�p
            float azimuth = Mathf.Atan2(directionToTarget.z, directionToTarget.x) * Mathf.Rad2Deg;
            turretBase.rotation = Quaternion.Euler(0, azimuth, 0);

            // ������]�i�p�j�̌v�Z�ƓK�p
            float horizontalDistance = new Vector2(directionToTarget.x, directionToTarget.z).magnitude;
            float elevation = Mathf.Atan2(directionToTarget.y, horizontalDistance) * Mathf.Rad2Deg;
            turretBarrel.localRotation = Quaternion.Euler(-elevation, 0, 0);

            // �f�o�b�O�p�F�R���\�[���Ɋp�x���o��
            Debug.Log($"���ʊp: {azimuth}�x, �p: {elevation}�x");
        }
    }
}