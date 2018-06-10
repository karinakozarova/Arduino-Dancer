using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Song_Selector : MonoBehaviour {

    public GameObject songSelectionTemplate;
    public GameObject songSelectionList;

    private AudioSource audioSource;

    private string currentSongPath;

    private float audioStartTime;
    private float audioLength;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        Parse();
	}

	void Update () {
	    if (audioSource.time >= (audioStartTime + audioLength))
        {
            audioSource.Play();
            audioSource.time = audioStartTime;
        }

        if (audioSource.volume < 0.95f) audioSource.volume = Mathf.Lerp(audioSource.volume, 1.0f, Time.deltaTime); //smooth transition
        else audioSource.volume = 1.0f; //direct transition

	}
    /// <summary>
    /// get song data when song is selected
    /// </summary>
    void Parse()
    {
        DirectoryInfo info = new DirectoryInfo(Game_Data.songDirectory);
        FileInfo[] smFiles = info.GetFiles("*.sm", SearchOption.AllDirectories);
        for (int i = 0; i < smFiles.Length; i++) // loop all files
        {
            Song_Parser parser = new Song_Parser();
            Song_Parser.Metadata songData = parser.Parse(smFiles[i].FullName);

            audioStartTime = songData.sampleStart;
            audioLength = songData.sampleLength;

            if (songData.valid)
            {
                //Instantiate(Object original, Vector3 position, Quaternion rotation);
                // Quaternion.identity - "no rotation" - the object is perfectly aligned with the world or parent axes
                GameObject songObj = (GameObject)Instantiate(songSelectionTemplate, songSelectionList.transform.position, Quaternion.identity);
                songObj.GetComponentInChildren<Text>().text = songData.title + " - " + songData.artist; //the text that is inside the new songObj becomes titl - artist (example - Bad Romance - Gaga)


                songObj.transform.parent = songSelectionList.transform;//the songObj depends on the whole list position

                songObj.transform.localScale = new Vector3(1, 1, 1); // scale of the transform relative to the parent.


                //Get access to the button control
                Button songBtn = songObj.GetComponentInChildren<Button>();

                //if there is a bannerPath file inside of the songData object, load the banner instead of the text
                if (File.Exists(songData.bannerPath))
                {
                    Texture2D texture = new Texture2D(275, 52); // 275 width, 52 height,
                    texture.LoadImage(File.ReadAllBytes(songData.bannerPath)); // add banner as texture image


                    // init a sprite that uses the texture, a sharp edged (edge radius - 0) rectangle, a pivot equal to the vector and 100pixels per unit
                    songBtn.image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    songBtn.image.material.SetColor("_Color", Color.white); //no color tin over the button

                    songObj.GetComponentInChildren<Text>().enabled = false; //don't show the button text

                }

                //once the button is clicked, start the song, and if there is an error, handle it
                songBtn.onClick.AddListener(delegate { StartSong(songData); });

                 //the event is triggered when the pointer enters the trigger zone of the button
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;


                //if you aren't already playing the song preview start a song preview of the song
                entry.callback.AddListener(eventData => { if (songData.musicPath != currentSongPath) { StartCoroutine(PreviewTrack(songData.musicPath)); } } );

                //add the new trigger to the list of triggers in the button
                songBtn.GetComponent<EventTrigger>().triggers.Add(entry);
            }
        }
    }

    /// <summary>
    /// starts playing the song when user hoovers
    /// </summary>
    /// <param name="musicPath"> path to audio file</param>
    /// <returns></returns>
    IEnumerator PreviewTrack(string musicPath)
    {
        string url = string.Format("file://{0}", musicPath);
        WWW www = new WWW(url);

        while (!www.isDone) yield return null;

        AudioClip clip = www.GetAudioClip(false, false);
        audioSource.clip = clip;

        audioSource.Play(); // start audiosource
        audioSource.time = audioStartTime;
        currentSongPath = musicPath;
        audioSource.volume = 0; // don't play videoclip sound
    }

    /// <summary>
    /// starts the selected song
    /// </summary>
    /// <param name="songData"> song metadata</param>
    void StartSong(Song_Parser.Metadata songData)
    {
        Game_Data.chosenSongData = songData;
        SceneManager.LoadScene(2);
    }
}
