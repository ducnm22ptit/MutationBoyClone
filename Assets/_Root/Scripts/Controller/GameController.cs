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
        PlayStageCurrent();
    }

    public void PlayStageCurrent()
    {
        if (_currentStage != null)
        {
            DestroyImmediate(_currentStage.gameObject,true);
        }
        
       _currentStage =  Instantiate(gameConfig.Stages[DataController.Instance.currentStage]);
    }


    public void NextStage()
    {
        if (DataController.Instance.currentStage == DataController.Instance.indexStage)
        {
            DataController.Instance.indexStage += 1;         
        }

        SoundController.Instance.StopAllSound();
        DataController.Instance.currentStage += 1;
        PlayStageCurrent();
        GameController.Instance.PlayBackgroundMusicStart();
    }

    public void PlayBackgroundMusicStart()
    {
        SoundController.Instance.SetBackgroundMusic(AudioClipName.InGameBackground);

        SoundController.Instance.ContinueBackgroundMusic();
    }
}
