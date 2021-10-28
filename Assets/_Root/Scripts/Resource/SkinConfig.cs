using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.Serialization;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SkinConfig", menuName = "ScriptableObjects/SkinConfig")]
public class SkinConfig : SerializedScriptableObject
{
    public List<SkinData> SkinList = new List<SkinData>();
}

public class SkinData
{
    public string Skin_Name;
    public string Skin_Price; 
    public SkeletonDataAsset Skin_Type;
}
