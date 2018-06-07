using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Audio : MonoBehaviour {

    private static BG_Audio instance = null;

    /// <summary>
    /// gets the background audio instance
    /// </summary>
    public static BG_Audio Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// change status of bg audio
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this) // destroy object
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this; 

        DontDestroyOnLoad(this.gameObject); 
    }
}
