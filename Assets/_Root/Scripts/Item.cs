using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Item : MonoBehaviour
{

    [SerializeField] private Button itemdBtn;


    [SerializeField] private TextMeshProUGUI itemIndex;


    [SerializeField] private Sprite spritePass;

    [SerializeField] private Sprite spriteCurrent;

    [SerializeField] private Sprite spriteLock;

    [SerializeField] private HomeController homeController;

    [SerializeField] private GameController gameController;

    private int _saveItem;

    private Image _image;

    private void Awake()
    {
        itemdBtn.onClick.AddListener(CheckStatusItem);

        _image = itemdBtn.gameObject.GetComponent<Image>();

    }
    public void CheckActiveItem(int i)
    {
        _saveItem = i;

        if (i < DataController.Instance.indexStage)
        {
            _image.sprite = spritePass;

            itemIndex.text = (i + 1).ToString();

        }
        else if (i == DataController.Instance.indexStage)
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
        DataController.Instance.currentStage = _saveItem;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //if (_saveItem < DataController.Instance.indexStage)
        //{
        //    DataController.Instance.currentStage = _saveItem;
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        //else if (_saveItem == DataController.Instance.indexStage)
        //{
        //    gameController.PlayStageCurrent(_saveItem);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }

}
