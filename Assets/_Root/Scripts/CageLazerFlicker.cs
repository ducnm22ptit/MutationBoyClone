using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageLazerFlicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer lazerSprite;

    [SerializeField] private SpriteRenderer fadeLazerSprite;

    private bool _isFliker;

    private void Start()
    {
        InvokeRepeating("LoopFlicker", 0, 0.1f);
    }

    private void LoopFlicker()
    {
        _isFliker = !_isFliker;

        if (_isFliker)
        {
            lazerSprite.gameObject.SetActive(false);
            fadeLazerSprite.gameObject.SetActive(true);
        }
        else
        {
            lazerSprite.gameObject.SetActive(true);
            fadeLazerSprite.gameObject.SetActive(false);
        }
    }
}
