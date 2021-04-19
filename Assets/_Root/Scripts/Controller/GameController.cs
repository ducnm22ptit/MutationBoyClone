using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public GameConfig gameConfig;

    private BaseStage _currentStage;

    [SerializeField] Button replayBtn;


    void Start()
    {
        replayBtn.onClick.AddListener(ReplayGame);

        PlayBackgroundMusicStart();
        PlayStageCurrent();
    }

    public void PlayStageCurrent()
    {
        replayBtn.gameObject.SetActive(true);

        if (_currentStage != null)
        {
            DestroyImmediate(_currentStage.gameObject, true);
        }

        _currentStage = Instantiate(gameConfig.Stages[DataController.Instance.currentStage]);
    }

    public void NextStage()
    {
        if (DataController.Instance.currentStage == DataController.Instance.indexStage)
        {
            DataController.Instance.indexStage += 1;
        }
        DataController.Instance.currentStage += 1;
        SoundController.Instance.StopAllSound();
        DataController.Instance.indexLevel = 0;
        PlayStageCurrent();
        GameController.Instance.PlayBackgroundMusicStart();
    }
    private void ReplayGame()
    {
        DOTween.KillAll(false);
        DataController.Instance.indexLevel = 0;
        PlayStageCurrent();
    }
    public void PlayBackgroundMusicStart()
    {
        SoundController.Instance.SetBackgroundMusic(AudioClipName.InGameBackground);

        SoundController.Instance.ContinueBackgroundMusic();
    }


}
