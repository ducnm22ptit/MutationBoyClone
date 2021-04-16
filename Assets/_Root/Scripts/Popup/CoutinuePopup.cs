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


    private void Start()
    {
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
            circleFill.DOFillAmount(0, 0);
        });
    }

    private void MinusingCoin()
    {
        DataController.Instance.coinReward -= 200;
        minusCoinBtn.gameObject.SetActive(false);
        continuePopup.SetActive(false);

    }

    private void FreeCoin()
    {
        continuePopup.SetActive(false);
        GameController.Instance.PlayStageCurrent();

    }
    private void OnEnable()
    {
        circleFill.DOKill();
    }

}
