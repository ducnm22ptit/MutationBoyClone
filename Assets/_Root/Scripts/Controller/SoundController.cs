using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioSource audioSourceBg;

    [SerializeField] private List<AudioClip> audioClips;


    public void PlaySoundFx(AudioClipName audioClipName) //play effect sound
    {
        if (DataController.Instance.isSound)
        {
            audioSource.PlayOneShot(audioClips[(int)audioClipName]);
        }
    }

    // BackgroundMusic
    public void SetBackgroundMusic(AudioClipName audioClipName)
    {
        audioSourceBg.clip = audioClips[(int)audioClipName];
    }

    public void PauseAllSound()
    {
        audioSourceBg.Pause();
    }
    public void ContinueBackgroundMusic()
    {

        if (DataController.Instance.isMusic && DataController.Instance.isSound)
        {
            audioSourceBg.Play();
        }
    }
}

public enum AudioClipName
{
    Airplane, //0
    Breathing, //1
    Dino, //2
    InGameBackground,//3
    UIBackground,
    Dino0,
    Dino1,
    Dino2,
    Dragon,
    Gorilla,
    Lion,
    Rhino,
    Robot,
    Whale,
    DinoWalk,
    Fly,
    Karate,
    Run1,
    Run2,
    Scream,
    Touch,
    Walk,
    Door,
    EarthQuake,
    Electric,
    FailChoose1,
    FailChoose2,
    GameOver,
    Laser,
    Mountain,
    Pass,
    Trans,
    WallFall,
    Wind,
    WinPopup,
    WinPopupAdd

}
