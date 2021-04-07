using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HomeController : MonoBehaviour
{
    [SerializeField] private Button tapToStartBtn;

    [SerializeField] private Button stageBtn;

    [SerializeField] private Button settingBtn;

    [SerializeField] private GameObject stagePopup, settingPopup;

    [SerializeField] private TextMeshProUGUI coinText;

    private int _nextScene;


    private void Start()
    {
        _nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        tapToStartBtn.onClick.AddListener(NextToScene);

        stageBtn.onClick.AddListener(OpenStagePopup);
        settingBtn.onClick.AddListener(OpenSetting);

        SoundController.Instance.SetBackgroundMusic(AudioClipName.InGameBackground);

        SoundController.Instance.ContinueBackgroundMusic();

        coinText.text = DataController.Instance.coinReward.ToString();
    }
    private void NextToScene()
    {
        SceneManager.LoadScene(_nextScene);
    }
    private void OpenStagePopup()
    {
        stagePopup.gameObject.SetActive(true);    
    }
    private void OpenSetting()
    {
        settingPopup.gameObject.SetActive(true);
    }
}
