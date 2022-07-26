using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiceThrowerController : MonoBehaviour
{
    public static DiceThrowerController Instance;
    public Action<int> OnDiceThrown;
    
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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of the DiceThrowerController!");
            Destroy(gameObject);
        }
        
        _playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        _diceSpawnRateCounter = numThatDiceSpawnsAt;
        this.transform.position = PlayerSpawner.Instance.throwerSpawnPoint.position;
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
                Instantiate(dicePrefab, transform.position + new Vector3(0f, 1f, -1f), Quaternion.identity);
                _diceSpawnRateCounter += numThatDiceSpawnsAt;
                DiceCheckZone.Instance.Activate(true);
                audiomanager.instance.Play("Grab");
            }
            else
            {
                Instantiate(boulderPrefab, transform.position + new Vector3(0f, 1f, -1f), Quaternion.identity);
            }
            _timeSinceLastThrow = Time.time + throwRate;
            OnDiceThrown?.Invoke(_bouldersSpawnedCount);
            _throwDice = false;
        }
    }

    private void Update()
    {
        Move();
        Throw();
    }

    public int GetThrowNumThatDiceSpawnsAt()
    {
        return numThatDiceSpawnsAt;
    }

    public float GetTimeSinceLastThrow()
    {
        return _timeSinceLastThrow;
    }
}
