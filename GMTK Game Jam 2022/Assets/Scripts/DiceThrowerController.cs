using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceThrowerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private InputAction verticalMovement;

    [SerializeField] private CharacterController controller;

    [SerializeField] private float moveSpeed = 1f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        verticalMovement = playerInputActions.DiceThrower.VerticalMovement;
        verticalMovement.Enable();

        playerInputActions.DiceThrower.ThrowDice.performed += DoThrow;
        playerInputActions.DiceThrower.ThrowDice.Enable();
    }

    private void OnDisable()
    {
        verticalMovement.Disable();
        playerInputActions.DiceThrower.ThrowDice.Disable();
    }

    private void DoThrow(InputAction.CallbackContext obj)
    {
        Debug.Log("Throw Dice");
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(verticalMovement.ReadValue<float>(), 0, 0);
        controller.Move(moveVector * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
