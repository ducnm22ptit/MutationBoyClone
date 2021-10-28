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

        //var i = DataController.Instance.indexStage;

        for (int i = 0; i < gameConfig.Stages.Count; i++)
        {
            Item item = Instantiate(itemPrefab, content.transform);      

            item.CheckActiveItem(i);
        }
    }

    private void BackToHome()
    { 
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        itemPopup.SetActive(false);
    }
}
