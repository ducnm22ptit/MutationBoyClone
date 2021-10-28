using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine.Unity.Editor;
using TMPro;

public class StoreItem : MonoBehaviour
{
    [SerializeField] Button CoinBtn;

    [SerializeField] SkeletonGraphic skinAnim;

    private GameObject _coinObj;

    private int _ID;

    private SkeletonDataAsset _skin;

    private string _price;

    private string _name;


    private void Start()
    {
        CoinBtn.onClick.AddListener(PurchaseSkin);
        _coinObj = FindObjectOfType<CoinController>().gameObject;
    }

    public void SetSkinStatus(int index, string skinName, string skinPrice, SkeletonDataAsset skinType)
    {
        this._ID = index;
        this._name = skinName;
        this._price = skinPrice;
        this._skin = skinType;

        this.gameObject.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = this._name;
        this.gameObject.transform.GetChild(1).GetComponentInChildren<SkeletonGraphic>().skeletonDataAsset = this._skin;
        SpineEditorUtilities.ReloadSkeletonDataAssetAndComponent(this.gameObject.transform.GetChild(1).GetComponentInChildren<SkeletonGraphic>());
        this.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = this._price;

        ShowStatus();
    }
    private void ShowStatus()
    {
        DataController.Instance.ID_SKin = this._ID;

        if (DataController.Instance.IsPurchse == true)
        {
            CoinBtn.gameObject.SetActive(false);
            skinAnim.color = Color.white;
            switch (_ID)
            {
                case 0:
                    skinAnim.AnimationState.SetAnimation(0, "1/idle", true);
                    break;
                case 1:
                    skinAnim.AnimationState.SetAnimation(0, "0/idle", true);
                    break;
                default:
                    skinAnim.AnimationState.SetAnimation(0, "idle", true);
                    break;
            }
        }

        else
        {
            skinAnim.color = Color.black;
        }
    }

    private void PurchaseSkin()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);

        if (DataController.Instance.coinReward >= float.Parse(_price))
        {
            DataController.Instance.ID_SKin = this._ID;
            DataController.Instance.IsPurchse = true;
            CoinBtn.gameObject.SetActive(false);      
            float coinValue = float.Parse(_coinObj.GetComponentInChildren<TextMeshProUGUI>().text);
            coinValue -= float.Parse(_price);
            _coinObj.GetComponentInChildren<TextMeshProUGUI>().text = coinValue.ToString();
            DataController.Instance.coinReward -= float.Parse(_price);

            skinAnim.color = Color.white; 

            switch (_ID)
            {
                case 0:
                    skinAnim.AnimationState.SetAnimation(0, "1/idle", true);
                    break;
                case 1:
                    skinAnim.AnimationState.SetAnimation(0, "0/idle", true);
                    break;
                default:
                    skinAnim.AnimationState.SetAnimation(0, "idle", true);
                    break;
            }
        }
    }
}
