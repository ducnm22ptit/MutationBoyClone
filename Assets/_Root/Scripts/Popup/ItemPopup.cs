using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{
    [SerializeField] private GameObject content;

    [SerializeField] private Item itemPrefab;

    [SerializeField] private GameConfig gameConfig;

    [SerializeField] private Button backBtn;

    [SerializeField] private GameObject itemPopup;

    //private List<Item> _items = new List<Item>();


    private void Start()
    {
        backBtn.onClick.AddListener(BackToHome);

        for (int i = 0; i < gameConfig.numberItem; i++)
        {
            Item item = Instantiate(itemPrefab, content.transform);       
            item.CheckActiveItem(i, gameConfig);
        }
    }

    private void BackToHome()
    {
        itemPopup.SetActive(false);
    }
}
