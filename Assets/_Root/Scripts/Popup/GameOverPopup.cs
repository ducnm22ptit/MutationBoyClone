using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameOverPopup : MonoBehaviour
{
    private void OnEnable()
    {
        DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
        {
            PopupController.Instance.HidePopup(PopupName.GameoverPopup);
            DataController.Instance.indexLevel = 0;
            GameController.Instance.PlayStageCurrent();
        }).OnComplete(() =>
        {
            GameController.Instance.PlayBackgroundMusicStart();
        });
    }


}
