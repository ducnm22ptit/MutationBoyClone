using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig")]

public class GameConfig : ScriptableObject
{
    public bool canUnlockAllItem;

    public List<BaseStage> Stages = new List<BaseStage>();
}
