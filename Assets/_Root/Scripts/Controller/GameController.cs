using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameConfig gameConfig;

    private BaseStage _currentStage;

    void Start()
    {
        PlayBackgroundMusicStart();

        PlayStageCurrent(DataController.Instance.currentStage);
    }

    public void PlayStageCurrent(int index)
    {
        if (_currentStage != null)
        {
            DestroyImmediate(_currentStage.gameObject,true);
        }

       _currentStage =  Instantiate(gameConfig.Stages[index]);
    }

    public void NextStage()
    {
        SoundController.Instance.StopAllSound();
        DataController.Instance.indexStage += 1;
        DataController.Instance.currentStage = DataController.Instance.indexStage;
        PlayStageCurrent(DataController.Instance.currentStage);
        GameController.Instance.PlayBackgroundMusicStart();
    }

    public void PlayBackgroundMusicStart()
    {
        SoundController.Instance.SetBackgroundMusic(AudioClipName.InGameBackground);

        SoundController.Instance.ContinueBackgroundMusic();
    }
}
