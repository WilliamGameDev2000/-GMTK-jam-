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
    [SerializeField] private float gravityMultiplier = 1f;

    private Vector3 velocity = new Vector3(0, 0, 0);

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        GameStateManager.Instance.OnStateChange += OnGameStateChange;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnStateChange -= OnGameStateChange;
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

    private void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(movement.ReadValue<Vector2>().x, 0, movement.ReadValue<Vector2>().y);
        controller.Move(moveVector * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }

    private void OnGameStateChange(State NewState)
    {
        enabled = NewState == State.Gameplay;
    }
}
