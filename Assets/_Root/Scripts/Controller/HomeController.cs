using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Spine.Unity;
using Spine.Unity.Editor;
using TMPro;


public class HomeController : Singleton<HomeController>
{
    [SerializeField] Button tapToStartBtn;

    [SerializeField] Button stageBtn;

    [SerializeField] Button settingBtn;

    [SerializeField] Button shopBtn;

    [SerializeField] GameObject stagePopup, settingPopup, storePopup;

    [SerializeField] TextMeshProUGUI coinText;

    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] ShopConfig _shopConfig;

    [SerializeField] SkeletonGraphic _character;


    private void Start()
    {
        LoadSkinCharacter();

        tapToStartBtn.onClick.AddListener(NextToScene);

        tapToStartBtn.gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.7f).SetLoops(-1, LoopType.Yoyo);

        stageBtn.onClick.AddListener(OpenStagePopup);

        settingBtn.onClick.AddListener(OpenSetting);

        shopBtn.onClick.AddListener(OpenStore);

        SoundController.Instance.SetBackgroundMusic(AudioClipName.UIBackground);

        SoundController.Instance.ContinueBackgroundMusic();

        coinText.text = ((int)DataController.Instance.coinReward).ToString();

        levelText.text = ("Level " + (DataController.Instance.indexStage + 1).ToString());
    }

    public void LoadSkinCharacter()
    {
        _character.skeletonDataAsset = _shopConfig.CharacterInShopList[DataController.Instance.IDSkinCurrent].Character_Skin;
        SpineEditorUtilities.ReloadSkeletonDataAssetAndComponent(_character);
        switch (DataController.Instance.IDSkinCurrent)
        {
            case 0:
                _character.AnimationState.SetAnimation(0, "0/walk", true);
                _character.transform.DORotate(new Vector3(0,0,0), 0f);
                break;
            case 1:
                _character.AnimationState.SetAnimation(0, "1/run", true);
                _character.transform.DORotate(new Vector3(0,180,0),0f);
                break;
            case 2:
                _character.AnimationState.SetAnimation(0, "0/run", true);
                _character.transform.DORotate(new Vector3(0, 0, 0), 0f);
                break;
            case 3:
                _character.AnimationState.SetAnimation(0, "walk", true);
                _character.transform.DORotate(new Vector3(0, 0, 0), 0f);
                break;
            case 4:
                _character.AnimationState.SetAnimation(0, "walk", true); 
                _character.transform.DORotate(new Vector3(0, 180, 0), 0f);
                break;
        }
    }

    public void NextToScene()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        DataController.Instance.indexLevel = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OpenStagePopup()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        stagePopup.gameObject.SetActive(true);
    }
    private void OpenSetting()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        settingPopup.gameObject.SetActive(true);
    }

    private void OpenStore()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        storePopup.gameObject.SetActive(true);
    }
}
