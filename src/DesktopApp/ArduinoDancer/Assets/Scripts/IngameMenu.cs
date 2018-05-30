using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IngameMenu : MonoBehaviour {
    string mainMenuScene = "Main Menu";
    string controlsScene = "Controls";
    string scoreScene = "Score";

    public void RenderMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RenderControls()
    {
        SceneManager.LoadScene(controlsScene);
    }

    public void RenderScore()
    {
        SceneManager.LoadScene(scoreScene);
    }
}
