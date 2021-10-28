using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine.Unity.Editor;
using TMPro;

public class StoreItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _animName;

    [SerializeField] Button _useBtn, _animPriceObj;

    [SerializeField] SkeletonGraphic _anim;

    [SerializeField] GameObject _coinObj;

    private int _ID;

    private SkeletonDataAsset _skin;

    private string _price;

    private string _name;

    private int _indexDefault;

    private void Start()
    {
        _indexDefault = 0;
        _coinObj = FindObjectOfType<CoinController>().gameObject;
        _animPriceObj.onClick.AddListener(PurchaseCharacter);
        _useBtn.onClick.AddListener(UseCharacter);
    }

    public void SetCharacterInShop(int index, string characterName, SkeletonDataAsset characterSkin, string characterPrice)
    {
        if(index == _indexDefault)
        {
            DataController.Instance.IsPurchse = true;
        }
        else
        {
            this._price = characterPrice;
            _animPriceObj.GetComponentInChildren<TextMeshProUGUI>().text = this._price;      
        }

        this._ID = index;
        this._name = characterName;
        this._skin = characterSkin;

        _animName.text = this._name;
        _anim.skeletonDataAsset = this._skin;
        SpineEditorUtilities.ReloadSkeletonDataAssetAndComponent(_anim);

        ShowStatus();
    }
    private void ShowStatus()
    {
        DataController.Instance.ID_Character = this._ID; // get ID for checking data "true" or "false"

        if (DataController.Instance.IsPurchse == true)
        {
            _animPriceObj.gameObject.SetActive(false);
            _useBtn.gameObject.SetActive(true);
            _anim.color = Color.white;
            switch (_ID)
            {
                case 0:
                    _anim.AnimationState.SetAnimation(0, "0/walk", true);
                    break;
                case 1:
                    _anim.AnimationState.SetAnimation(0, "1/idle", true);
                    break;
                case 2:
                    _anim.AnimationState.SetAnimation(0, "0/idle", true);
                    break;
                default:
                    _anim.AnimationState.SetAnimation(0, "idle", true);
                    break;
            }
        }

        else
        {
            _anim.color = Color.black;
        }
    }

    private void PurchaseCharacter()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);

        if (DataController.Instance.coinReward >= float.Parse(_price))
        {
            DataController.Instance.ID_Character = this._ID;
            DataController.Instance.IsPurchse = true;
            _animPriceObj.gameObject.SetActive(false);
            _useBtn.gameObject.SetActive(true);
            float coinValue = float.Parse(_coinObj.GetComponentInChildren<TextMeshProUGUI>().text);
            coinValue -= float.Parse(_price);
            _coinObj.GetComponentInChildren<TextMeshProUGUI>().text = coinValue.ToString();
            DataController.Instance.coinReward -= float.Parse(_price);

            _anim.color = Color.white; 

            switch (_ID)
            {
                case 1:
                    _anim.AnimationState.SetAnimation(0, "1/idle", true);
                    break;
                case 2:
                    _anim.AnimationState.SetAnimation(0, "0/idle", true);
                    break;
                default:
                    _anim.AnimationState.SetAnimation(0, "idle", true);
                    break;
            }
        }
    }

    private void UseCharacter()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        DataController.Instance.IDSkinCurrent = this._ID;
        HomeController.Instance.LoadSkinCharacter();
    }
}
