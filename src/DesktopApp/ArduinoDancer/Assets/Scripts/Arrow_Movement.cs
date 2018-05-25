using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    

	// Use this for initialization
	void Start () {

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


    // Update is called once per frame
    void Update() {
        if (PauseMenu.isPaused == false)
        {

            int res = 0;
            arrowSpeed = gen.arrowSpeed;
            Vector3 tempPos = transform.position;
            tempPos.y -= arrowSpeed;
            transform.position = tempPos;


            // support both WASD and arrows from keyboard as input 
            bool isPressedDownKeyboardLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
            bool isPressedDownKeyboardDown = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
            bool isPressedDownKeyboardUp = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
            bool isPressedDownKeyboardRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);

            bool isPressedDownLeft = false;
            bool isPressedDownDown = false;
            bool isPressedDownUp = false;
            bool isPressedDownRight = false;

            if (isPressedDownKeyboardLeft)
            {
                isPressedDownLeft = true;
                Debug.Log("Left");
            }
            else if (isPressedDownKeyboardDown)
            {
                isPressedDownDown = true;
                Debug.Log("Down");

            }
            else if (isPressedDownKeyboardUp)
            {
                isPressedDownUp = true;
                Debug.Log("Up");

            }
            else if (isPressedDownKeyboardRight)
            {
                isPressedDownRight = true;
                Debug.Log("Right");

            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("ingame");
            }

            if (isPressedDownLeft && dir == direction.left) CheckLocation();
            if (isPressedDownDown && dir == direction.down) CheckLocation();
            if (isPressedDownUp && dir == direction.up) CheckLocation();
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
