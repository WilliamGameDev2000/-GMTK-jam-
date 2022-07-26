using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    public bool timerOn = false;

    public TMP_Text timerText;

    public TMP_Text roundEndText;

    void Start()
    {
        timerOn = true;
        roundEndText.enabled = false;

        GameManager.Instance.countdownTimer = this;
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
                GameManager.Instance.GameOver("Thrower Wins!!!");
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
