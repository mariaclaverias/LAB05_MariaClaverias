using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling myPooling;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private bool canShoot;

    [SerializeField] private float count = 0f;
    [SerializeField] private int countBullets = 0;

    private void Awake()
    {
        myPooling.SetUp(this.transform);
        myPooling.onEnableObject += PrintBulletCount;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= PrintBulletCount;
    }

    private void FixedUpdate()
    {
        count += Time.deltaTime;

        if (count > fireRate && canShoot)
        {
            myPooling.GetObject();
            count = 0;
        }
    }

    private void PrintBulletCount()
    {
        countBullets++;
        //Debug.Log(countBullets);
    }
}
