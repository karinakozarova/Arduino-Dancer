using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Score_Handler : MonoBehaviour
{
    public float score = 0.0f;
    public float multiplier = 1.0f;
    public Text scoreText;

    private AudioSource heartAudio;
    private GameObject heart;
    private Renderer render;
    private List<GameObject> arrows;

    private const float scoreVal = 100.0f;
    private const float strumOffset = 0.1f;

    void Start()
    {
        heart = GameObject.FindGameObjectWithTag("Player");
        heartAudio = heart.GetComponent<AudioSource>();
    }

    void Update()
    {
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
}
