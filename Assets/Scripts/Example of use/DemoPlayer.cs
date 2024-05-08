using Player.Motion;
using UnityEngine;

public class DemoPlayer : MonoBehaviour
{
    private MotionCreator motionCreator;

    [SerializeField]
    private GameObject targetCamera;
    [SerializeField]
    private float speed1 = 2f;
    [SerializeField]
    private float speed2 = 0.5f;
    [SerializeField]
    private float speed3 = 1f;

    private void Start()
    {
        motionCreator = new();
    }

    private void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position
            = motionCreator
            .Create(inputDirection)
            .ObjectView(targetCamera)
            .PlaneMotion()
            .AdvancedForSpeed(speed1, speed2, speed3)
            .ForceVector;
    }
}