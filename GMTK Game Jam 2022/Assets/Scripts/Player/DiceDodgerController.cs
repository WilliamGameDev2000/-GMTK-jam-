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

    private Vector2 moveInput = Vector2.zero;
    private Vector3 velocity = new Vector3(0, 0, 0);

    [SerializeField] private PlayerSpawner playerSpawner;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.DiceDodger.Movement;
        movement.Enable();

        this.transform.position = playerSpawner.dodgerSpawnPoints[PlayerInputManagerPrefab.Instance.playerID - 1].position;
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

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(moveSpeed * Time.deltaTime * moveVector);
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }
}
