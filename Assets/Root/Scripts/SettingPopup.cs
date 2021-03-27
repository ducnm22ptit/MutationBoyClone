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

    }
    private void DisableSound()
    {
        disableSound.gameObject.SetActive(true);
        enableSound.gameObject.SetActive(false);

    }
    private void ToggleSound()
    {
        if (DataController.Instance.isSound == true)
        {
            DisableSound();
            SoundController.Instance.Pausing();
            DataController.Instance.isSound = false;
        }
        else
        {
            DataController.Instance.isSound = true;
            EnableSound();
            SoundController.Instance.Playing();
            
        }
    }
    private void EnableMusic()
    {
        disableMusic.gameObject.SetActive(false);

    }
    private void DisableMusic()
    {
        disableMusic.gameObject.SetActive(true);

    }
    private void ToggleMusic()
    {
        if (DataController.Instance.isMusic == true)
        {
            DisableMusic();
            DataController.Instance.isMusic = false;
            SoundController.Instance.Pausing();
        }
        else if (DataController.Instance.isMusic == false)
        {
            if (DataController.Instance.isSound == true)
            {
                EnableMusic();
                DataController.Instance.isMusic = true;
                SoundController.Instance.Playing();
            }
            else
            {
                EnableMusic();
                DataController.Instance.isMusic = true;
                SoundController.Instance.Pausing();
            }
                
        }
    }
}
