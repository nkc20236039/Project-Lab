using PlayerMotion;
using UnityEngine;
using UnityEngine.InputSystem;

public class DemoPlayer : MonoBehaviour
{
    private MotionCreator motionCreator;
    private PlayerInputActions inputAction;
    private Vector2 input;

    [SerializeField]
    private GameObject targetCamera;
    [SerializeField]
    private float forwardSpeed = 2f;
    [SerializeField]
    private float backSpeed = 0.5f;
    [SerializeField]
    private float sideSpeed = 1f;

    private void Start()
    {
        motionCreator = new();
        inputAction = new();
        inputAction.Player.Move.performed += OnMove;
        inputAction.Player.Move.canceled += OnMove;
        inputAction.Enable();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        IMotionGettable creator = motionCreator
            .Create(input)
            .ObjectView(targetCamera)
            .PlaneMotion()
            .AdvancedForSpeed(forwardSpeed, backSpeed, sideSpeed);

        transform.position = creator.ForceVector;
        transform.rotation = creator.CharacterRotation(transform.rotation, 0.8f);
    }


}