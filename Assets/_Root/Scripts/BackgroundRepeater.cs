using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private Vector3 StartPostion;
    private float repeater;
    [SerializeField] private float speed;
    void Start()
    {
        StartPostion = GetComponent<RectTransform>().localPosition;
        repeater = GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (GetComponent<RectTransform>().localPosition.x < StartPostion.x - repeater)
        {
            GetComponent<RectTransform>().localPosition = StartPostion;
        }
    }
}
