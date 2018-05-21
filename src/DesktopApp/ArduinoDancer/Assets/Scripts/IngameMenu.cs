using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IngameMenu : MonoBehaviour {
    string mainMenuScene = "Main Menu";
    public void RenderMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
