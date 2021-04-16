using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flicker : MonoBehaviour
{
    [SerializeField] private List<LineRenderer> lines = new List<LineRenderer>();

    [SerializeField] private float width;

    [SerializeField] private float time;


    private void OnEnable()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            ShowUp(lines[i]);
        }
    }

    private void ShowUp(LineRenderer lineRenderer)
    {
        float myFloat = 0;

        DOTween.To(() =>
        {
            return myFloat;
        },
        x =>
        {
            myFloat = x;
            lineRenderer.endWidth = x;
            lineRenderer.startWidth = x;
        },
        width,
        time);
    }
}
