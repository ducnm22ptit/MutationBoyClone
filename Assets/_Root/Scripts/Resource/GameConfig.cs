using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]

public class GameConfig : ScriptableObject
{
    public int numberItem;

    public int currentItem;

    public bool canUnlockAllItem;

    public List<BaseStage> Stages = new List<BaseStage>();

}
