﻿using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class Arrow_Movement : MonoBehaviour {

    public GameObject arrowBack;
    public Text scoreText;

    private Step_Generator gen;
    private float arrowSpeed = 0;
    private Score_Handler scoreHandler;
    private bool scoreApplied = false;

    public direction dir;
    public enum direction {  left, down, up, right };
    private const float strumOffset = 0.075f;
    private const float despawnTime = 1.5f;
    
    private  int start = 0;
    SerialPort stream = new SerialPort("COM3", 9600);

	// Use this for initialization
	void Start () {
        try
        {
            if (start == 0 && !stream.IsOpen)
            {
                Debug.Log("Stream is open");
                stream.Open();

            }
            start += 1;
        }
        catch { Debug.Log("stream.is not open.."); }
        stream.ReadTimeout = 2000000;
        gen = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Step_Generator>();
        scoreHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Score_Handler>();

        switch(GetComponent<SpriteRenderer>().sprite.name)
        {
            case "arrowsheet_down":
                dir = direction.down;
                break;
            case "arrowsheet_left":
                dir = direction.left;
                break;
            case "arrowsheet_right":
                dir = direction.right;
                break;
            case "arrowsheet_up":
                dir = direction.up;
                break;
        }
	}


    public void Close()
    {
        stream.Close();
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(1);
    }

    // Update is called once per frame
    void Update() {
        int res = 0;
        arrowSpeed = gen.arrowSpeed;
        Vector3 tempPos = transform.position;
        tempPos.y -= arrowSpeed;
        transform.position = tempPos;
        if (stream.IsOpen)
        {
            try
            {
                     // waiter();
                res = stream.ReadByte();
                //Debug.Log(res);
            }
            catch { }
          
         
        }
        /*
        // change here to be not the keyboard button but the unity input!
        bool isPressedDownLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isPressedDownDown = Input.GetKeyDown(KeyCode.DownArrow);
        bool isPressedDownUp = Input.GetKeyDown(KeyCode.UpArrow);
        bool isPressedDownRight = Input.GetKeyDown(KeyCode.RightArrow);
        */

        bool isPressedDownKeyboardLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isPressedDownKeyboardDown = Input.GetKeyDown(KeyCode.DownArrow);
        bool isPressedDownKeyboardUp = Input.GetKeyDown(KeyCode.UpArrow);
        bool isPressedDownKeyboardRight = Input.GetKeyDown(KeyCode.RightArrow);

        bool isPressedDownLeft = false;
        bool isPressedDownDown = false;
        bool isPressedDownUp = false;
        bool isPressedDownRight = false;

        if (res == 1 || isPressedDownKeyboardLeft)
        {
            isPressedDownLeft = true;
            Debug.Log("Left");
        }
        else if (res == 2 || isPressedDownKeyboardDown)
        {
            isPressedDownDown = true;
            Debug.Log("Down");

        }
        else if (res == 3 || isPressedDownKeyboardUp)
        {
            isPressedDownUp = true;
            Debug.Log("Up");

        }
        else if (res == 4 || isPressedDownKeyboardRight)
        {
            isPressedDownRight = true;
            Debug.Log("Right");

        }

        if (isPressedDownLeft && dir == direction.left) CheckLocation();
        if (isPressedDownDown && dir == direction.down) CheckLocation();
        if (isPressedDownUp&& dir == direction.up) CheckLocation();
        if (isPressedDownRight && dir == direction.right) CheckLocation();

        //Missed
        if (transform.position.y < arrowBack.transform.position.y - strumOffset)
        {
            GetComponent<Renderer>().material.SetColor("_Color", new Color(0.5f, 0.0f, 0.0f));
            StartCoroutine(DespawnArrow());
            if (!scoreApplied)
            {
                scoreApplied = true;
                scoreHandler.SendMessage("LoseScore");
            }
        }
    }

    void CheckLocation()
    {
        if (transform.position.y >= arrowBack.transform.position.y - strumOffset && transform.position.y <= arrowBack.transform.position.y + strumOffset)
        {
            arrowBack.GetComponent<Animator>().SetBool("isLit", true);
            scoreHandler.SendMessage("AddScore");
            Destroy(this.gameObject);
        }
    }

    IEnumerator DespawnArrow()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
