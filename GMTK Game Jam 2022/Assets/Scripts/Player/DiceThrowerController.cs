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

    [SerializeField] private DiceSpawn diceSpawner;

    Vector3 moveVector = Vector3.zero;
    private bool throwDice = false;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        verticalMovement = playerInputActions.DiceThrower.VerticalMovement;
        verticalMovement.Enable();

        //playerInputActions.DiceThrower.ThrowDice.performed += DoThrow;
        playerInputActions.DiceThrower.ThrowDice.Enable();
    }

    private void OnDisable()
    {
        verticalMovement.Disable();
        playerInputActions.DiceThrower.ThrowDice.Disable();
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        throwDice = context.action.triggered;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = new Vector3(context.ReadValue<float>(), 0, 0);
    }

    private void Move()
    {
        controller.Move(moveVector * moveSpeed * Time.deltaTime);
    }

    private void Throw()
    {
        if(throwDice)
        {
            Debug.Log("Throw Dice");
            diceSpawner.SpawnDice(this.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            throwDice = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Throw();
    }

}
