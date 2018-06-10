using UnityEngine;
using System.Collections;

public class BG_Colour_Changer : MonoBehaviour {

    private Camera camera;
    private float speed = 0.5f;

    private const float lerpLimit = 0.025f;

	void Start () {
        camera = GetComponent<Camera>();
	}

	void Update () {
        int hue = Mathf.PingPong(Time.time * speed, 1); // time in seconds since the start of the frame * 0.5< value < 1
        HSBColor randCol = new HSBColor(hue, 1, 1);
        randCol.s = randCol.s / 2; //desaturate
        camera.backgroundColor = randCol.ToColor(); // change background color
    }
}
