using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;


    public void PlayOnce(AudioClipName audioClipName) //play effect sound
    {
        if (DataController.Instance.isSound)
        {
            audioSource.PlayOneShot(audioClips[(int)audioClipName]);
        }
    }

    // BackgroundMusic
    public void SetBackgroundMusic(AudioClipName audioClipName)
    {
        audioSource.clip = audioClips[(int)audioClipName];
    }

    public void PauseBackgroundMusic()
    {
        audioSource.Pause();
    }
    public void ContinueBackgroundMusic()
    {
        if (DataController.Instance.isMusic && DataController.Instance.isSound)
        {
            audioSource.Play();
        }
    }
}

public enum AudioClipName
{
    Airplane, //0
    Breathing, //1
    Dino, //2
    InGameBackground //3

}
