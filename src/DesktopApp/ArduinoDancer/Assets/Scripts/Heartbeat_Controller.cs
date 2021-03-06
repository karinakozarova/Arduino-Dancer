﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Heartbeat_Controller : MonoBehaviour
{

    public float currentBPM = 0.0f;
    public bool editingBPM = false;

    private float frames = 60.0f;

    private float decayTimer = 0.0f;
    private float prevBeatTimer = 0.0f;
    private float beatTimer = 0;
    private float animCounter = 0.0f;
    private Animator anim;
    private AudioSource audioSource;
    private bool songLoaded = false;

    private float originalBPM = 0.0f;
    private const float bpmChangeBuffer = 10.0f;
    private const float lerpLimit = 0.1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Song_Parser.Metadata meta = Game_Data.chosenSongData;

        StartCoroutine(LoadTrack(meta.musicPath, meta));

        if (meta.bpm != 0) originalBPM = meta.bpm;
        else originalBPM = 120;
        currentBPM = originalBPM;
    }

    void Update()
    {
        ControllerHandler();
        HeartBeat();
        if (!audioSource.isPlaying && songLoaded)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1); //Song is over
    }

    IEnumerator LoadTrack(string path, Song_Parser.Metadata meta)
    {
        string url = string.Format("file://{0}", path);
        WWW www = new WWW(url);

        while (!www.isDone) yield return null; // download isnt finished

        AudioClip clip = www.GetAudioClip(false, false); // doesnt matter if it's 2d or 3d, no need to be downloaded completely
        audioSource.clip = clip;

        songLoaded = true;
        audioSource.Play();

        GameObject manager = GameObject.FindGameObjectWithTag("GameManager");
        manager.GetComponent<Step_Generator>().InitSteps(meta, Game_Data.difficulty);
    }

    /// <summary>
    /// beat the heart DEPRECATING
    /// </summary>
    void HeartBeat()
    {
        if (songLoaded && !editingBPM)
        {
            float secondsPerBeat = frames / currentBPM; //Calc how long a beat is in seconds

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
        if (anim.GetBool("isBeat")) anim.SetBool("isBeat", false);

        if (Input.GetKeyDown(KeyCode.N)){
            // restore pitch to the normal
            audioSource.pitch =  1;
            editingBPM = false;
        }else if(Input.GetKeyDown(KeyCode.Space)) {
            // changing BPM
            editingBPM = true;
            anim.SetBool("isBeat", true);

            //calc the BPM
            currentBPM = (1.0f / beatTimer) * frames;

            prevBeatTimer = beatTimer;
            decayTimer = prevBeatTimer * 1.5f;
            beatTimer = 0.0f;
            SongBPMChange();
        }

        if ((decayTimer -= Time.deltaTime) <= 0) editingBPM = false;
    }

    /// <summary>
    /// changes pitch of song
    /// </summary>
    void SongBPMChange()
    {

        float newPitch = currentBPM / originalBPM;
        if (Mathf.Abs(audioSource.pitch - newPitch) > lerpLimit) // smooth change
            audioSource.pitch = Mathf.Lerp(audioSource.pitch, currentBPM / originalBPM, Time.deltaTime);
        else // just change
            audioSource.pitch = currentBPM / originalBPM;
    }
}
