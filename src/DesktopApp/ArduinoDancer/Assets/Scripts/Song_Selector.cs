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

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        Parse();
	}
	
	// Update is called once per frame
	void Update () {
	    if (audioSource.time >= (audioStartTime + audioLength))
        {
            audioSource.Play();
            audioSource.time = audioStartTime;
        }

        if (audioSource.volume < 0.95f) audioSource.volume = Mathf.Lerp(audioSource.volume, 1.0f, Time.deltaTime);
        else audioSource.volume = 1.0f;
        
	}
    /// <summary>
    /// get song data when song is selected
    /// </summary>
    void Parse()
    {
        DirectoryInfo info = new DirectoryInfo(Game_Data.songDirectory);
        FileInfo[] smFiles = info.GetFiles("*.sm", SearchOption.AllDirectories);
        for (int i = 0; i < smFiles.Length; i++)
        {
            Song_Parser parser = new Song_Parser();
            Song_Parser.Metadata songData = parser.Parse(smFiles[i].FullName);

            audioStartTime = songData.sampleStart;
            audioLength = songData.sampleLength;

            if (songData.valid)
            {
                GameObject songObj = (GameObject)Instantiate(songSelectionTemplate, songSelectionList.transform.position, Quaternion.identity);
                songObj.GetComponentInChildren<Text>().text = songData.title + " - " + songData.artist;
                songObj.transform.parent = songSelectionList.transform;
                songObj.transform.localScale = new Vector3(1, 1, 1); 

                //Get access to the button control
                Button songBtn = songObj.GetComponentInChildren<Button>();
                if (File.Exists(songData.bannerPath))
                {
                    Texture2D texture = new Texture2D(275, 52);
                    texture.LoadImage(File.ReadAllBytes(songData.bannerPath));
                    songBtn.image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    songBtn.image.material.SetColor("_Color", Color.white);
                    songObj.GetComponentInChildren<Text>().enabled = false;
                }
                songBtn.onClick.AddListener(delegate { StartSong(songData); });

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener(eventData => { if (songData.musicPath != currentSongPath) { StartCoroutine(PreviewTrack(songData.musicPath)); } } );

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
       //  Debug.Log("Starting Preview for " + musicPath);
        string url = string.Format("file://{0}", musicPath);
        WWW www = new WWW(url);

        while (!www.isDone) yield return null;
    
        AudioClip clip = www.GetAudioClip(false, false);
        audioSource.clip = clip;

        audioSource.Play();
        audioSource.time = audioStartTime;
        currentSongPath = musicPath;
        audioSource.volume = 0;
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
