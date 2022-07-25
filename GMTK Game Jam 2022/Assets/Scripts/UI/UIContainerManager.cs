using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContainerManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private GameObject gameModeContainer;
    [SerializeField] private GameObject howToPlayContainer;
    
    private GameObject activeContainer;

    public void Awake()
    {
        SetActiveContainer(mainMenuContainer);
    }

    public void SetActiveContainer(GameObject _containerToActivate)
    {
        if(activeContainer != null)
        {
            activeContainer.SetActive(false);
        }
        activeContainer = _containerToActivate;
        activeContainer.SetActive(true);
    }

    public void OnGameModeButtonPressed()
    {
        SetActiveContainer(gameModeContainer);
    }
    public void OnHowToPlayButtonPressed()
    {
        SetActiveContainer(howToPlayContainer);
    }
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnBackButtonPressed()
    {
        SetActiveContainer(mainMenuContainer);
    }

    public void OnCompetitiveButtonPressed()
    {
        SceneManager.LoadScene("FreeForAll");
    }

    public void OnCooperativeButtonPressed()
    {
        SceneManager.LoadScene("1V3");
    }

    public void OnTutorialButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
