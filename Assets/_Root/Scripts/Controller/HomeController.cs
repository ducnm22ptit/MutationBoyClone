using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class HomeController : MonoBehaviour
{
    [SerializeField] private Button tapToStartBtn;

    [SerializeField] private Button stageBtn;

    [SerializeField] private Button settingBtn;

    [SerializeField] private GameObject stagePopup, settingPopup;

    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private TextMeshProUGUI levelText;



    private void Start()
    {
        tapToStartBtn.onClick.AddListener(NextToScene);

        tapToStartBtn.gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.7f).SetLoops(-1, LoopType.Yoyo);

        stageBtn.onClick.AddListener(OpenStagePopup);

        settingBtn.onClick.AddListener(OpenSetting);

        SoundController.Instance.SetBackgroundMusic(AudioClipName.UIBackground);

        SoundController.Instance.ContinueBackgroundMusic();

        coinText.text = ((int)DataController.Instance.coinReward).ToString();

        levelText.text = ("Level " + (DataController.Instance.indexStage + 1).ToString());
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
}
