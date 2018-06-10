using UnityEngine;
using System.Collections;

public class Difficulty_Menu_Handler : MonoBehaviour {

    string selectSongScene = "Song Selection";
    /// <summary>
    /// Sets difficulty to beginner
    /// </summary>
    public void SetBeginner() {
        Game_Data.difficulty = Song_Parser.difficulties.beginner;
        UnityEngine.SceneManagement.SceneManager.LoadScene(selectSongScene);
    }

    /// <summary>
    /// Sets difficulty to easy
    /// </summary>
    public void SetEasy() {
        Game_Data.difficulty = Song_Parser.difficulties.easy;
        UnityEngine.SceneManagement.SceneManager.LoadScene(selectSongScene);
    }

    /// <summary>
    /// Sets difficulty to medium
    /// </summary>
    public void SetMedium() {
        Game_Data.difficulty = Song_Parser.difficulties.medium;
        UnityEngine.SceneManagement.SceneManager.LoadScene(selectSongScene);
    }

    /// <summary>
    /// Sets difficulty to hard
    /// </summary>
    public void SetHard() {
        Game_Data.difficulty = Song_Parser.difficulties.hard;
        UnityEngine.SceneManagement.SceneManager.LoadScene(selectSongScene);
    }

    /// <summary>
    /// Sets difficulty to extreme
    /// </summary>
    public void SetChallenge() {
        Game_Data.difficulty = Song_Parser.difficulties.challenge;
        UnityEngine.SceneManagement.SceneManager.LoadScene(selectSongScene);
    }
}
