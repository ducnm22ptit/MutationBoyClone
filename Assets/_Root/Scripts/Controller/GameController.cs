using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameConfig gameConfig;

    private BaseStage _currentStage;

    void Start()
    {
        PlayStageCurrent(DataController.Instance.indexStage);

        PlayBackgroundMusicStart();   
    }

    public void PlayStageCurrent(int index)
    {
        Debug.Log(index);

        if (_currentStage != null)
        {
            DestroyImmediate(_currentStage.gameObject,true);
        }

       _currentStage =  Instantiate(gameConfig.Stages[index]);
    }

    public void NextStage()
    {
        DataController.Instance.indexStage += 1;
        PlayStageCurrent(DataController.Instance.indexStage);
    }

    public void PlayBackgroundMusicStart()
    {
        SoundController.Instance.SetBackgroundMusic(AudioClipName.InGameBackground);

        SoundController.Instance.ContinueBackgroundMusic();
    }
}
