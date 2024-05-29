using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;

    private Vector2 cameraLock;
    private PlayerInputActions inputAction;

    private void Awake()
    {
        inputAction = new();

        inputAction.Player.Aiming.performed += OnAiming;

        inputAction.Enable();
    }

    private void Update()
    {

    }

    private void OnAiming(InputAction.CallbackContext context)
    {
        
    }
}
