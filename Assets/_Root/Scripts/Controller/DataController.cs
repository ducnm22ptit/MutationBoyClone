using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    private const string IS_SOUND = "IS_SOUND";

    private const string IS_MUSIC = "IS_MUSIC";

    private const string INDEX_STAGE = "INDEX_STAGE";

    private const string CURRENT_STAGE = "CURRENT_STAGE";

    private const string INDEX_LEVEL = "INDEX_LEVEL";

    private const string COIN_REWARD = "COIN_REWARD";

    private const string ID_CHARACTER = "ID_CHARACTER";

    private const string ID_SKIN_CURRENT = "ID_SKIN_CURRENT";

    private const string IS_PURCHASE = "IS_PURCHASE";

    public bool isSound
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString(IS_SOUND, "true"));
        }
        set
        {
            PlayerPrefs.SetString(IS_SOUND, value.ToString());
        }
    }
    public bool isMusic
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString(IS_MUSIC, "true"));
        }
        set
        {
            PlayerPrefs.SetString(IS_MUSIC, value.ToString());
        }
    }


    public int indexStage
    {
        get
        {
            return PlayerPrefs.GetInt(INDEX_STAGE, 0);
        }
        set
        {
            PlayerPrefs.SetInt(INDEX_STAGE, value);
        }
    }

    public int currentStage
    {
        get
        {
            return PlayerPrefs.GetInt(CURRENT_STAGE, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CURRENT_STAGE, value);
        }
    }

    public int indexLevel
    {
        get
        {
            return PlayerPrefs.GetInt(INDEX_LEVEL + "-" + currentStage, 0);
        }
        set
        {
            PlayerPrefs.SetInt(INDEX_LEVEL + "-" + currentStage, value);
        }
    }

    public float coinReward
    {
        get
        {
            return PlayerPrefs.GetFloat(COIN_REWARD, 1000);
        }
        set
        {
            PlayerPrefs.SetFloat(COIN_REWARD, value);
        }
    }

    public int ID_Character
    {
        get
        {
            return PlayerPrefs.GetInt(ID_CHARACTER, 0);
        }

        set
        {
            PlayerPrefs.SetInt(ID_CHARACTER, value);
        }
    }

    public bool IsPurchse
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString(ID_Character + "-"+ IS_PURCHASE, "false"));
        }

        set
        {
            PlayerPrefs.SetString(ID_Character + "-" + IS_PURCHASE, value.ToString());
        }
    }

    public int IDSkinCurrent
    {
        get
        {
            return PlayerPrefs.GetInt(ID_SKIN_CURRENT, 0);
        }

        set
        {
            PlayerPrefs.SetInt(ID_SKIN_CURRENT, value);
        }
    }
}

