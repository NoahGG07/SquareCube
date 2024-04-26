using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicScript : MonoBehaviour
{
    public static BgMusicScript instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
