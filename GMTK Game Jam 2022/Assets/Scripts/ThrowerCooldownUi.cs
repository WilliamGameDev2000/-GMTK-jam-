using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowerCooldownUi : MonoBehaviour
{
    [SerializeField] private Image cooldownPanel;
    [SerializeField] private RawImage cooldownImage;
    [SerializeField] private Texture boulderSprite;
    [SerializeField] private Texture diceSprite;
    [SerializeField] private Color activeImageColour;
    [SerializeField] private Color inactiveImageColour;
    private int _diceIndexCounter;

    private void OnEnable()
    {
        DiceThrowerController.Instance.OnDiceThrown += OnDodgerThrow;
    }

    private void OnDisable()
    {
        DiceThrowerController.Instance.OnDiceThrown -= OnDodgerThrow;
    }

    private void Start()
    {
        cooldownImage.texture = boulderSprite;
        _diceIndexCounter = DiceThrowerController.Instance.GetThrowNumThatDiceSpawnsAt()-1;
    }

    private void Update()
    {
        if (Time.time < DiceThrowerController.Instance.GetTimeSinceLastThrow())
        {
            cooldownImage.color = inactiveImageColour;
        }
        else
        {
            cooldownImage.color = activeImageColour;
        }
    }

    private void OnDodgerThrow(int throwIndex)
    {
        if (throwIndex == _diceIndexCounter)
        {
            cooldownImage.texture = diceSprite;
            _diceIndexCounter += (DiceThrowerController.Instance.GetThrowNumThatDiceSpawnsAt());
        }
        else
        {
            cooldownImage.texture = boulderSprite;
        }
    }
}
