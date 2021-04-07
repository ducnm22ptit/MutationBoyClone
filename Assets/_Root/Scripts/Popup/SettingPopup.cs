using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button soundBtn, musicBtn;
    [SerializeField] private GameObject disableMusic, enableSound, disableSound;
    [SerializeField] private GameObject settingPopup;



    private void Start()
    {
        closeBtn.onClick.AddListener(ClosePopup);

        soundBtn.onClick.AddListener(ToggleSound);

        musicBtn.onClick.AddListener(ToggleMusic);

        if (DataController.Instance.isSound)
        {
            EnableSound();
        }
        else
        {
            DisableSound();
        }
        if (DataController.Instance.isMusic)
        {
            EnableMusic();
        }
        else
        {
            DisableMusic();
        }

    }

    private void ClosePopup()
    {
        settingPopup.gameObject.SetActive(false);
    }
    private void EnableSound()
    {
        enableSound.gameObject.SetActive(true);
        disableSound.gameObject.SetActive(false);
        if (DataController.Instance.isSound == false)
        {
            DataController.Instance.isSound = true;
            SoundController.Instance.ContinueBackgroundMusic();
        }

    }
    private void DisableSound()
    {
        disableSound.gameObject.SetActive(true);
        enableSound.gameObject.SetActive(false);
        DataController.Instance.isSound = false;
        SoundController.Instance.PauseBackgroundMusic();

    }
    private void ToggleSound()
    {
        if (DataController.Instance.isSound == true)
        {
            DisableSound();
        }
        else
        {
            EnableSound();
        }
    }
    private void EnableMusic()
    {
        disableMusic.gameObject.SetActive(false);
        if (DataController.Instance.isMusic == false)
        {
            DataController.Instance.isMusic = true;
            SoundController.Instance.ContinueBackgroundMusic();
        }
    }
    private void DisableMusic()
    {
        disableMusic.gameObject.SetActive(true);
        DataController.Instance.isMusic = false;
        SoundController.Instance.PauseBackgroundMusic();
    }
    private void ToggleMusic()
    {
        if (DataController.Instance.isMusic == true)
        {
            DisableMusic();
        }
        else
        {
            EnableMusic();
        }

    }
}
