using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContainerManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private GameObject gameModeContainer;
    [SerializeField] private GameObject howToPlayContainer;

    [SerializeField] private GameObject competitiveGameModeContainer;
    [SerializeField] private GameObject cooperativeGameModeContainer;

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

    public void OnBackButtonPressed(GameObject returnContainer)
    {
        SetActiveContainer(returnContainer);
    }

    public void OnCompetitiveButtonPressed()
    {
        SetActiveContainer(competitiveGameModeContainer);
    }

    public void OnCooperativeButtonPressed()
    {
        SetActiveContainer(cooperativeGameModeContainer);
    }

    public void OnNumberOfPlayersSelected(int numberOfPlayers)
    {
        PlayerSpawner.Instance.SetNumberOfPlayers(numberOfPlayers);
    }

    public void OnCompetitiveGameModeSelected()
    {
        //SceneManager.LoadScene("FreeForAll");
        SceneManager.LoadScene("MultiplayerTest");
    }

    public void OnCooperativeGameModeSelected()
    {
        SceneManager.LoadScene("1V3");
    }

    public void OnTutorialButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
