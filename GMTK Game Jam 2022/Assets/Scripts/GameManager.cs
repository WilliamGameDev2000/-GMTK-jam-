using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public enum GameMode
    {
        COMPETITIVE,
        COOPERATIVE,
    }
    public GameMode gamemode;

    public CountdownTimer countdownTimer;

    public bool gameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
        else
        {
            Debug.LogError("There should only be one instance of the GameManager!");
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void GameOver(string winner)
    {
        GameManager.Instance.gameOver = true;
        countdownTimer.timerOn = false;
        countdownTimer.roundEndText.text = winner;
        countdownTimer.roundEndText.enabled = true;
    }
}
