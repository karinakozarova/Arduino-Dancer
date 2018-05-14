﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Score_Handler : MonoBehaviour {

    public float score = 0.0f;
    public float multiplier = 1.0f;
    public Text scoreText;

    private Heartbeat_Controller heartScript;
    private AudioSource heartAudio;
    private GameObject heart;
    private Renderer render;
    private List<GameObject> arrows;

    private const float scoreVal = 100.0f;
    private const float strumOffset = 0.1f;

	// Use this for initialization
	void Start () {
        heart = GameObject.FindGameObjectWithTag("Player");
        heartScript = heart.GetComponent<Heartbeat_Controller>();
        heartAudio = heart.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        multiplier = heartAudio.pitch;
        scoreText.text = "Score: " + score;
	}

    /// <summary>
    /// ++score when the arrow is missed
    /// </summary>
    void AddScore()
    {
        score += scoreVal * multiplier;
    }

    /// <summary>
    /// Removes from score when the arrow is missed DEPRECATED
    /// </summary>
    void LoseScore()
    {
        // it's not cool for the little kids to remove from score, so this is DEPRECATED
        //score -= scoreVal * multiplier;
       // if (score < 0) score = 0;
        
    }
}
