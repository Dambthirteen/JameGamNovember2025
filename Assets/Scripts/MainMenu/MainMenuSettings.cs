using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour
{

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
}
