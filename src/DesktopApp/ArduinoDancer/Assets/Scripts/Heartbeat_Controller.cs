using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Heartbeat_Controller : MonoBehaviour {

    public float currentBPM = 0.0f;
    public bool editingBPM = false;

    public Text debugText;
    public Text debugText2;

    private float decayTimer = 0.0f;
    private float prevBeatTimer = 0.0f;
    private float beatTimer = 0;
    private float prevBPM = 0;
    private float animCounter = 0.0f;
    private Animator anim;
    private AudioSource audioSource;
    private bool songLoaded = false;

    private float originalBPM = 0.0f;
    private const float bpmChangeBuffer = 10.0f;
    private const float lerpLimit = 0.1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource>();
        Song_Parser.Metadata meta = Game_Data.chosenSongData;

        StartCoroutine(LoadTrack(meta.musicPath, meta));
        /*  debugText.text = "Title: " + meta.title + "\nArtist: " + meta.artist;
     
               debugText.text = "Title: " + meta.title +
                                "\nArtist: " + meta.artist +
                                "\nBanner Path: " + meta.bannerPath +
                                "\nBackground Path: " + meta.backgroundPath +
                                "\nMusic Path: " + meta.musicPath +
                                "\nOffset: " + meta.offset +
                                "\nSample Start: " + meta.sampleStart +
                                "\nSample Length: " + meta.sampleLength +
                                "\nBPM: " + meta.bpm +
                                "\n\nValid: " + meta.valid;
               */
        if (meta.bpm != 0) originalBPM = meta.bpm;
        else originalBPM = 120;
        currentBPM = originalBPM;
        prevBPM = currentBPM;
    }
	
	// Update is called once per frame
	void Update () {
		ControllerHandler ();
        SongBPMChange();
        HeartBeat();
        if (!audioSource.isPlaying && songLoaded) UnityEngine.SceneManagement.SceneManager.LoadScene(1); //Song is over
    }

    IEnumerator LoadTrack(string path, Song_Parser.Metadata meta)
    {
        Debug.Log(path);
        string url = string.Format("file://{0}", path);
        WWW www = new WWW(url);

        while (!www.isDone) yield return null;
        
        AudioClip clip = www.GetAudioClip(false, false);
        audioSource.clip = clip;

        songLoaded = true;
        audioSource.Play();

        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        manager.GetComponent<Step_Generator>().InitSteps(meta, Game_Data.difficulty);
    }

    /// <summary>
    /// beat the heart
    /// </summary>
    void HeartBeat()
    {
        if (songLoaded && !editingBPM)
        {
            //Calc how long a beat is in seconds
            float secondsPerBeat = 60.0f / currentBPM;

            //If the time has passed for one beat, beat the heart and reset
            animCounter += Time.deltaTime;
            if (animCounter >= secondsPerBeat)
            {
                animCounter = 0;
                anim.SetBool("isBeat", true);
            }
        }
    }
    /// <summary>
    /// change BPM by sending the new rhythm using the spacebar
    /// </summary>
	void ControllerHandler()
	{
        beatTimer += Time.deltaTime;
        if (anim.GetBool("isBeat")) anim.SetBool ("isBeat", false);
		
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
            editingBPM = true;
			anim.SetBool ("isBeat", true);
            
            //calc the BPM
            prevBPM = currentBPM;
            currentBPM = (1.0f / beatTimer) * 60.0f;

            prevBeatTimer = beatTimer;
            decayTimer = prevBeatTimer * 1.5f;
            beatTimer = 0.0f;
        }

        if ((decayTimer -= Time.deltaTime) <= 0) editingBPM = false;
	}

    /// <summary>
    /// changes pitch of song
    /// </summary>
    void SongBPMChange()
    {
        //when kari stops testing -> uncomment
        float newPitch = currentBPM / originalBPM;
        if (Mathf.Abs(audioSource.pitch - newPitch) > lerpLimit)
            audioSource.pitch = Mathf.Lerp(audioSource.pitch, currentBPM / originalBPM, Time.deltaTime);
        else
            audioSource.pitch = currentBPM / originalBPM;
        
         
    }
}