using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    public bool isSound
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString("isSound","true"));
        }
        set
        {
            PlayerPrefs.SetString("isSound", value.ToString());
        }
    } 
    public bool isMusic
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString("isMusic", "true"));
        }
        set
        {
            PlayerPrefs.SetString("isMusic", value.ToString());
        }
    }



}

