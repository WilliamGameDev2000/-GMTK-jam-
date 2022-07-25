using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceDodgerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private InputAction movement;

    [SerializeField] private CharacterController controller;

    [SerializeField] private float moveSpeed = 1f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.DiceDodger.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(movement.ReadValue<Vector2>().x, 0, movement.ReadValue<Vector2>().y);
        controller.Move(moveVector * moveSpeed * Time.deltaTime);
    }
}
