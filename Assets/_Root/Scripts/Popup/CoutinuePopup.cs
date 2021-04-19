using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class CoutinuePopup : MonoBehaviour
{
    [SerializeField] private GameObject continuePopup;

    [SerializeField] private Button freeBtn;

    [SerializeField] private Button minusCoinBtn;

    [SerializeField] private Image circleFill;

    private int _i;
    private void OnEnable()
    {
        _i = DataController.Instance.indexLevel;
        
        minusCoinBtn.gameObject.SetActive(true);
        if (DataController.Instance.coinReward < 200)
        {
            minusCoinBtn.gameObject.SetActive(false);
        }
        DataController.Instance.indexLevel = 0;
        freeBtn.onClick.AddListener(FreeCoin);
        minusCoinBtn.onClick.AddListener(MinusingCoin);
        CircleCountDown();
    }

    private void CircleCountDown()
    {
        circleFill.DOFillAmount(1, 5f).OnComplete(() =>
        {
            DataController.Instance.indexLevel = 0;
            GameController.Instance.PlayStageCurrent();
            GameController.Instance.PlayBackgroundMusicStart();
            continuePopup.SetActive(false);
        });
    }

    private void MinusingCoin()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        if (DataController.Instance.coinReward > 200)
        {
            DataController.Instance.coinReward -= 200;
        }
        DataController.Instance.indexLevel = _i;
        minusCoinBtn.gameObject.SetActive(false);
        continuePopup.SetActive(false);
        GameController.Instance.PlayBackgroundMusicStart();
        GameController.Instance.PlayStageCurrent();
    }

    private void FreeCoin()
    {
        SoundController.Instance.PlaySoundFx(AudioClipName.Touch);
        DataController.Instance.indexLevel = _i;
        continuePopup.SetActive(false);
        GameController.Instance.PlayBackgroundMusicStart();
        GameController.Instance.PlayStageCurrent();
    }

    private void OnDisable()
    {
        circleFill.fillAmount = 0;
        circleFill.DOKill();
    }
}
