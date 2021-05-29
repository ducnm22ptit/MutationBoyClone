using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeaterStage : MonoBehaviour
{
    private Vector3 StartPostion;
    private float repeater;
    [SerializeField] private float speed;
    void Start()
    {
        StartPostion = GetComponent<Transform>().localPosition;
        repeater = (GetComponent<BoxCollider2D>().size.x) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (GetComponent<Transform>().localPosition.x < StartPostion.x - repeater)
        {
            Debug.Log("123");
            GetComponent<Transform>().localPosition = StartPostion;
        }
    }
}
