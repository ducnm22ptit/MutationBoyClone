using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePopup : MonoBehaviour
{
    [SerializeField] GameObject Container;

    [SerializeField] SkinConfig SkinConfig;

    [SerializeField] StoreItem ItemStorePrefab;

    [SerializeField] Button BackBtn;

    [SerializeField] GameObject StorePopupObj;


    private void Start()
    {
        BackBtn.onClick.AddListener(BackToHome);
        GenerateSkin();
    }

    private void GenerateSkin()
    {
        for (int i = 0; i < SkinConfig.SkinList.Count; i++)
        {
            StoreItem item = Instantiate(ItemStorePrefab, Container.transform);
            var type = SkinConfig.SkinList[i].Skin_Type;
            var price = SkinConfig.SkinList[i].Skin_Price;
            var name = SkinConfig.SkinList[i].Skin_Name;
            item.SetSkinStatus(i, name, price, type);
        }
    }

    private void BackToHome()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        StorePopupObj.SetActive(false);
    }
}
