using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arrow_Movement : MonoBehaviour {

    public GameObject arrowBack;

    private Step_Generator gen;
    private float arrowSpeed = 0;
    private Score_Handler scoreHandler;
    private bool scoreApplied = false;
    private SerialPort stream;

    public direction dir;
    public enum direction {  left, down, up, right };
    private const float strumOffset = 0.075f;
    private const float despawnTime = 1.5f;

    public string port = "COM3";
    public int baudrate = 9600;

	// Use this for initialization
	void Start () {
        //Open();
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

    public void Open()
    {
        // Opens the serial port
        stream = new SerialPort(port, baudrate);
        stream.ReadTimeout = 50;
        stream.Open();
        //this.stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }


    public void Close()
    {
        stream.Close();
    }

    // Update is called once per frame
    void Update() {

        arrowSpeed = gen.arrowSpeed;
        Vector3 tempPos = transform.position;
        tempPos.y -= arrowSpeed;
        transform.position = tempPos;

        // change here to be not the keyboard button but the unity input!
       bool isPressedDownLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isPressedDownDown = Input.GetKeyDown(KeyCode.DownArrow);
        bool isPressedDownUp = Input.GetKeyDown(KeyCode.UpArrow);
        bool isPressedDownRight = Input.GetKeyDown(KeyCode.RightArrow);
        
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
