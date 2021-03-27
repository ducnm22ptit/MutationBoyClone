using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeController : MonoBehaviour
{
    [SerializeField] private Button tapToStartBtn;
    [SerializeField] private Button stageBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] GameObject stagePopup, settingPopup;
    private int nextScene;


    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        tapToStartBtn.onClick.AddListener(NextToScene);

        stageBtn.onClick.AddListener(OpenStagePopup);
        settingBtn.onClick.AddListener(OpenSetting);
        SoundController.Instance.PlayBackgroundMusic();
    }
    private void NextToScene()
    {
        SceneManager.LoadScene(nextScene);
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
