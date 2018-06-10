using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Handler : MonoBehaviour {

    [DllImport("user32.dll")]
    private static extern void FolderBrowserDialog();
    public Text warningText;

    /// <summary>
    /// starts game
    /// </summary>
    public void StartGameClick()
    {
        if (!Game_Data.validSongDir)
        {
            warningText.enabled = true;
            StartCoroutine(DespawnWarning());
        }
        else SceneManager.LoadScene(1);

    }

    /// <summary>
    /// removes the warning DEPRECATING
    /// </summary>
    IEnumerator DespawnWarning()
    {
        yield return new WaitForSeconds(2.5f);
        warningText.enabled = false;
    }

    /// <summary>
    /// Loads scene 3
    /// </summary>
    public void DifficultyClick()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Loads tutorial scene
    /// </summary>
    public void StartTutorial()
    {
        SceneManager.LoadScene("Тutorials");
    }


    /// <summary>
    /// quits game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// opens menu browser dialog to select song directory
    /// </summary>
    public void FindSongsClick()
    {
        System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

        System.Windows.Forms.DialogResult result = fbd.ShowDialog(); // shows dialog to select songs
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            Game_Data.songDirectory = fbd.SelectedPath; // make the selected path the song directory
            if(Song_Parser.IsNullOrWhiteSpace(Game_Data.songDirectory)) Game_Data.validSongDir = false;
            else Game_Data.validSongDir = true;
        }
    }
}
