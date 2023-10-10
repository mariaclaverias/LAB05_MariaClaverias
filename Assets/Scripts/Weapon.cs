using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject objPref;
    private float startTime = 0;

    public void ShootWeapon()
    {
        startTime += Time.deltaTime;
        if (startTime > 0.2f)
        {
            Instantiate(objPref, transform.position, transform.rotation);
            startTime = 0;
        }
    }
}