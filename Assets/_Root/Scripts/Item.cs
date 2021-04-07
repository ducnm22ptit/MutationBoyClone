using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] private Button itemdBtn;


    [SerializeField] private TextMeshProUGUI itemIndex;


    [SerializeField] private Sprite spritePass;

    [SerializeField] private Sprite spriteCurrent;

    [SerializeField] private Sprite spriteLock;



    private int _saveItem;
    private GameConfig _gameConfig;
    private Image _image;

    private void Awake()
    {
        itemdBtn.onClick.AddListener(CheckStatusItem);

        _image = itemdBtn.gameObject.GetComponent<Image>();

    }
    public void CheckActiveItem(int i, GameConfig gameConfig)
    {
        _saveItem = i + 1;
        _gameConfig = gameConfig;

        if (i < _gameConfig.currentItem)
        {
            _image.sprite = spritePass;

            itemIndex.text = (i + 1).ToString();
        }
        else if (i == _gameConfig.currentItem)
        {
            _image.sprite = spriteCurrent;
            itemIndex.text = (i + 1).ToString();
        }
        else
        {
            _image.sprite = spriteLock;
            itemIndex.gameObject.SetActive(false);
        }
    }

    public void CheckStatusItem()
    {
        if (_saveItem < _gameConfig.currentItem)
        {
            Debug.Log(_saveItem);
            Debug.Log("Passed");
        }
        else if (_saveItem == _gameConfig.currentItem)
        {
            Debug.Log(_saveItem);
            Debug.Log("Current");
        }
        else
        {
            Debug.Log("Lock");
        }
    }

}
