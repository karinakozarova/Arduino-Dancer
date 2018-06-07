using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class testingArduino : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM3", 9600);

    void Start () {
        if (!stream.IsOpen)
        {
            stream.Open();
            Debug.Log("Stream is open");
        }
    }
    
    void Update () {
        int res = 0;
        if (stream.IsOpen)
        {
            try
            {
                res = stream.ReadChar();
                // res = stream.ReadByte();
                Debug.Log(res);
            }
            catch { };

        }

        if (res == 1)
        {
            Debug.Log("Left");
        }
        else if (res == 2)
        {
            Debug.Log("Down");

        }
        else if (res == 3)
        {
            Debug.Log("Up");

        }
        else if (res == 4)
        {
            Debug.Log("Right");

        }
    }
}
