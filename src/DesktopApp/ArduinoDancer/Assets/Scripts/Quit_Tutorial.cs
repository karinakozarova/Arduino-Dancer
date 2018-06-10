using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Tutorial : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene("Main Menu");
	}
}
