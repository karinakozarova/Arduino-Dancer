using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllAudio : MonoBehaviour {
    //Stop all sounds
    private AudioSource[] allAudioSources;

	// Use this for initialization
	void Start () {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
	}
}
