using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string loseScene = "Lose";

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        // FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Breakout Quest");
        Application.Quit();
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(loseScene);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }
}
