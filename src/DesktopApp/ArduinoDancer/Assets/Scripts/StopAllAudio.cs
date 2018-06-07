using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllAudio : MonoBehaviour {
    private AudioSource[] allAudioSources;

	void Start () {
		// get all audio sources
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audioS in allAudioSources) // loop all audios
        	audioS.Stop(); //stop this audio
	}
}
