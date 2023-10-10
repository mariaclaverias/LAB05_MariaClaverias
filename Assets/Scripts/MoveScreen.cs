using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    [SerializeField]
    private float range = -35.28f;
    [SerializeField]
    private float speed;
    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos;
    }

    private void Update()
    {
        MoveScreenUpdate();
    }

    private void MoveScreenUpdate()
    {
        endPos.x -= speed * Time.deltaTime;
        transform.position = endPos;

        if (endPos.x <= range)
        {
            transform.position = startPos;
            endPos = transform.position;
        }
    }
}
