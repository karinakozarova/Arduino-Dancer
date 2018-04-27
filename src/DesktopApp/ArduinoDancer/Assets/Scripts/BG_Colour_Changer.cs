using UnityEngine;
using System.Collections;

public class BG_Colour_Changer : MonoBehaviour {

    private Camera camera;
    //private Color nextCol;
    private float speed = 0.5f;

    private const float lerpLimit = 0.025f;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        HSBColor randCol = new HSBColor(Mathf.PingPong(Time.time * speed, 1), 1, 1);
        randCol.s = randCol.s / 2;
        camera.backgroundColor = randCol.ToColor();
      //  Camera.main.backgroundColor = randCol.ToColor();
    }
}
