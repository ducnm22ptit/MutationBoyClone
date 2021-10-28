using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.Serialization;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ShopConfig", menuName = "ScriptableObjects/ShopConfig")]

public class ShopConfig : SerializedScriptableObject
{
    public List<CharacterData> CharacterInShopList = new List<CharacterData>();
}

public class CharacterData
{
    public string Character_Name;
    public string Character_Price;
    public SkeletonDataAsset Character_Skin;
}
