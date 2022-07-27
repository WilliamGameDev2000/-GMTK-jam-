using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContainerManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private GameObject gameModeContainer;
    [SerializeField] private GameObject howToPlayContainer;

    [SerializeField] private GameObject PlayerSelectContainer;

    private GameObject activeContainer;

    public void Awake()
    {
        SetActiveContainer(mainMenuContainer);
    }

    public void SetActiveContainer(GameObject _containerToActivate)
    {
        /*if(activeContainer != null)
        {
            activeContainer.SetActive(false);
        }*/
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

        #if UNITY_EDITOR //
        UnityEditor.EditorApplication.isPlaying = false;
        #endif // UNITY_EDITOR
    }

    public void OnBackButtonPressed(GameObject returnContainer)
    {
        SetActiveContainer(returnContainer);
    }

    public void OnCompetitiveButtonPressed()
    {
        GameManager.Instance.gamemode = GameManager.GameMode.COMPETITIVE;
        SetActiveContainer(PlayerSelectContainer);
    }

    public void OnCooperativeButtonPressed()
    {
        GameManager.Instance.gamemode = GameManager.GameMode.COOPERATIVE;
        SetActiveContainer(PlayerSelectContainer);
    }

    public void OnNumberOfPlayersSelected(int numberOfPlayers)
    {
        PlayerSpawner.Instance.SetNumberOfPlayers(numberOfPlayers);
    }

    public void OnLoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnTutorialButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
