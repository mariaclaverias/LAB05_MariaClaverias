using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private DynamicObjectPool objectPool;
    public float speed;
    public Score score;
    private Vector3 startPos;
    private bool isOut = false, isTrigger = false;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.position.x > 15f && isOut == false || isTrigger)
        {
            HideObject(objectPool);
        }
    }

    public void SetObjectPool(DynamicObjectPool objectPool)
    {
        startPos = transform.position;
        this.objectPool = objectPool;
    }

    public void InitVariables(Transform spawner)
    {
        transform.position = spawner.position;
        isOut = false;
        isTrigger = false;
    }

    private void HideObject(DynamicObjectPool objectPool)
    {
        objectPool.SetObject(gameObject);
        gameObject.SetActive(false);
        isOut = true;
        isTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trash")
        {
            score.AddScore(10f);
            isTrigger = true;
        }
    }
}
