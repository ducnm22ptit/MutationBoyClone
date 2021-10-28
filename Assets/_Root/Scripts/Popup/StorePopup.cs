using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePopup : MonoBehaviour
{
    [SerializeField] GameObject _container;

    [SerializeField] ShopConfig _shopConfig;

    [SerializeField] StoreItem _itemStorePrefab;

    [SerializeField] Button _backBtn;


    private void Start()
    {
        _backBtn.onClick.AddListener(BackToHome);
        GenerateCharacterInShop();
    }

    private void GenerateCharacterInShop()
    {
        for (int i = 0; i < _shopConfig.CharacterInShopList.Count; i++)
        {
            StoreItem item = Instantiate(_itemStorePrefab, _container.transform);
            var name = _shopConfig.CharacterInShopList[i].Character_Name;
            var skin = _shopConfig.CharacterInShopList[i].Character_Skin;
            var price = _shopConfig.CharacterInShopList[i].Character_Price;
            item.SetCharacterInShop(i, name, skin, price);
        }
    }

    private void BackToHome()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        this.gameObject.SetActive(false);
    }
}
