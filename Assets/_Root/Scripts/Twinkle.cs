using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Twinkle : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> twinkleList = new List<SpriteRenderer>();

    private bool _isFade = false;
    private void OnEnable()
    {
        InvokeRepeating("ShowTwinkle", 0.2f, 0.7f);
    }

    private void ShowTwinkle()
    {
        _isFade = !_isFade;

        if (_isFade)
        {
            for (int i = 0; i < twinkleList.Count; i++)
            {
                twinkleList[i].DOFade(0.6f, 0.7f);
                _isFade = true;
            }
        }
        else
        {
            for (int i = 0; i < twinkleList.Count; i++)
            {
                twinkleList[i].DOFade(0, 0.7f);
            }
        }

    }

}
