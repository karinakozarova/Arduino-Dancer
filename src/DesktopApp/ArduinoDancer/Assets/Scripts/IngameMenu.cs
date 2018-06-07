using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IngameMenu : MonoBehaviour {
    
    string mainMenuScene = "Main Menu";
    string controlsScene = "Controls";
    string scoreScene = "Score";


    /// <summary>
    /// loads the main meni
    /// </summary>
    public void RenderMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    /// <summary>
    /// quits the application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// renders the controls scene
    /// </summary>
    public void RenderControls()
    {
        SceneManager.LoadScene(controlsScene);
    }

    /// <summary>
    /// renders the score scene
    /// </summary>
    public void RenderScore()
    {
        SceneManager.LoadScene(scoreScene);
    }
}
