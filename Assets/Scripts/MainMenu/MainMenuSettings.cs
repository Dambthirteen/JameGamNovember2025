using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject DifficultyScreen;
    [SerializeField] GameObject Tutorial;

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void EasyMode()
    {
        DifficultyManager.StartTime = 60;
        StartGame();
    }

    public void MediumMode()
    {
        DifficultyManager.StartTime = 20;
        StartGame();
    }

    public void HardMode()
    {
        DifficultyManager.StartTime = 10;
        StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenTutorial()
    {
        Tutorial.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CloseTutorial()
    {
        Tutorial.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void GoToDifficultyScreen()
    {
        DifficultyScreen.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CloseDifficultyScreen()
    {
        DifficultyScreen.SetActive(false);
        MainMenu.SetActive(true);
    }
}
