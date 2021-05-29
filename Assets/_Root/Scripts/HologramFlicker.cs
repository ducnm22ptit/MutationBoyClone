using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HologramFlicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hologram;

    [SerializeField] private SpriteRenderer doctorHologram;

    private bool _isFliker = false;

    private void Start()
    {
        InvokeRepeating("Toggle", 0, 0.5f);
    }
    private void Toggle()
    {

        _isFliker = !_isFliker;

        if (_isFliker)
        {
            ShowOff(hologram);
        }
        else
        {
            ShowUp(hologram);
        }
    }

    private void ShowUp(SpriteRenderer holo)
    {
        holo.DOFade(1, 0.5f);
        doctorHologram.DOFade(1, 0.5f);
    }

    private void ShowOff(SpriteRenderer holo)
    {
        holo.DOFade(0, 0.5f);
        doctorHologram.DOFade(0, 0.5f);
    }
}
