using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Audio : MonoBehaviour {
    private static BG_Audio instance = null;
    public static BG_Audio Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
