using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] private SoundResource soundResource;
    [SerializeField] private AudioSource audioSource;
    public bool isTurnOn;



    public void PlayOnce(AudioClip audioClip)
    {
        if (DataController.Instance.isSound)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    public void Playing()
    {
        if (DataController.Instance.isSound)
        {
            audioSource.Play();
        }
    }

    public void Pausing()
    {
        audioSource.Pause();
    }
    public void PlayBackgroundMusic()
    {

        AudioClip audioClip = soundResource.InGame;
        audioSource.clip = audioClip;
        Playing();

    }

}
