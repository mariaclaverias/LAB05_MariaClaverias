using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPool : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject objPref;
    public Transform spawner;
    private float startTime = 0;

    public void ShootWeapon()
    {
        startTime += Time.deltaTime;

        if (startTime >= 0.2f)
        {
            GetObject();

            startTime = 0f;
        }
    }

    public void GetObject()
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<Bullet>().InitVariables(spawner);
        }
        else
        {
            tmp = Instantiate(objPref, spawner.position, transform.rotation);
            tmp.GetComponent<Bullet>().SetObjectPool(this);
            tmp.GetComponent<Bullet>().InitVariables(spawner);
            objectPool.Add(tmp);

            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }
    }

    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
}
