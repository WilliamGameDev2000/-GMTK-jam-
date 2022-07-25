using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    private bool timerOn = false;

    [SerializeField] private TMP_Text timerText;

    [SerializeField] private GameObject roundEndTextObjects;

    void Start()
    {
        timerOn = true;
        roundEndTextObjects.SetActive(false);
    }


    void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Timer finished");
                timeLeft = 0;
                timerOn = false;

                roundEndTextObjects.SetActive(true);
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{00 : 00}", seconds);
    }
}
