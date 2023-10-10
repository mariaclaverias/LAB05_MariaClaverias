using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling myPooling;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float speed;
    private bool isSetUp;

    private void OnEnable()
    {
        myPooling.onEnableObject += SetUp;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= SetUp;
    }

    private void SetUp()
    {
        if (!isSetUp)
        {
            if (myRigidbody == null)
            {
                myRigidbody = GetComponent<Rigidbody2D>();
            }

            myRigidbody.velocity = Vector3.left * speed;
            isSetUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }

        if (collision.tag == "Collector")
        {
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }
    }
}
