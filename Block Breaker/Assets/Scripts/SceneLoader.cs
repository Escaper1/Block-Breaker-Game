using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentIndex;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentIndex = currentSceneIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);


    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();

    }
 
    public void LoadLoadedScene()
    {
        SceneManager.LoadScene(currentIndex);
    }
public void QuitGame()
    {
        Application.Quit();

    }
}
