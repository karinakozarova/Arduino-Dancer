using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P)) // pause is triggered
        {
            if(isPaused) Resume();
            else Pause();
        }
	}

    /// <summary>
    /// resumes the time so that the game continues
    /// </summary>
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    /// <summary>
    /// stops the time so that the game is paused
    /// </summary>
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
