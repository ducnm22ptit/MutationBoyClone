using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class CoinController : Singleton<CoinController>
{

    [SerializeField] private TextMeshProUGUI coinText;

    public void ReceivingCoin()
    {
        float _myFloat = DataController.Instance.coinReward;

        DOTween.To(() =>
        {
            return _myFloat;
        }
        ,
        x =>
        {
            _myFloat = x;

            coinText.text = ((int)x).ToString();

            DataController.Instance.coinReward = x;
        },
        DataController.Instance.coinReward + 50,
        2f);
    }

 
}
