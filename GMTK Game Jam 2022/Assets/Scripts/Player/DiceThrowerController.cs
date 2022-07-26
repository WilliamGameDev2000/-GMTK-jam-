using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceThrowerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private GameObject boulderPrefab;
    [SerializeField] private int numThatDiceSpawnsAt;
    [SerializeField] private float throwRate;

    private PlayerInputActions _playerInputActions;
    private InputAction _verticalMovement;
    private Vector3 _moveVector = Vector3.zero;
    private bool _throwDice = false;
    private int _bouldersSpawnedCount;
    private int _diceSpawnRateCounter;
    private float _timeSinceLastThrow;

    [SerializeField] private PlayerSpawner playerSpawner;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        _diceSpawnRateCounter = numThatDiceSpawnsAt;
        this.transform.position = playerSpawner.throwerSpawnPoint.position;
    }

    private void OnEnable()
    {
        _verticalMovement = _playerInputActions.DiceThrower.VerticalMovement;
        _verticalMovement.Enable();

        //playerInputActions.DiceThrower.ThrowDice.performed += DoThrow;
        _playerInputActions.DiceThrower.ThrowDice.Enable();
    }

    private void OnDisable()
    {
        _verticalMovement.Disable();
        _playerInputActions.DiceThrower.ThrowDice.Disable();
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        _throwDice = context.action.triggered;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveVector = new Vector3(context.ReadValue<float>(), 0, 0);
    }

    private void Move()
    {
        controller.Move(_moveVector * moveSpeed * Time.deltaTime);
    }

    private void Throw()
    {
        if(_throwDice && Time.time > _timeSinceLastThrow)
        {
            _bouldersSpawnedCount++;
            if (_bouldersSpawnedCount >= _diceSpawnRateCounter)
            {
                Debug.Log("Throw Dice");
                Instantiate(dicePrefab, transform.position + new Vector3(0f, 1f, -1f), Quaternion.identity);
                _diceSpawnRateCounter += numThatDiceSpawnsAt;
            }
            else
            {
                Debug.Log("Throw Boulder");
                Instantiate(boulderPrefab, transform.position + new Vector3(0f, 1f, -1f), Quaternion.identity);
            }
            _timeSinceLastThrow = Time.time + throwRate;
            _throwDice = false;
        }
    }

    private void Update()
    {
        Move();
        Throw();
    }
}
