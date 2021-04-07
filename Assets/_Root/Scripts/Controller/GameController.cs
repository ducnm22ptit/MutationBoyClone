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
    }

    private void PlayStageCurrent(int index)
    {

        if (_currentStage != null)
        {
            DestroyImmediate(_currentStage);
        }

       _currentStage =  Instantiate(gameConfig.Stages[index]);
    }

    private void NextStage()
    {
        DataController.Instance.indexStage++;
        PlayStageCurrent(DataController.Instance.indexStage);
    }
}
