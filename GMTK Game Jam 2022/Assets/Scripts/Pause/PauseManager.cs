using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused = false;

    [SerializeField] GameObject PauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }
    }

    public void Play()
    {
        PauseUI.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR //
        UnityEditor.EditorApplication.isPlaying = false;
#endif // UNITY_EDITOR
    }

    void Pause()
    {
        PauseUI.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0f;
    }
}
