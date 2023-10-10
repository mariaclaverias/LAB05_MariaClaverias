using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectScript : MonoBehaviour
{
    private static GameObject persistentObject;

    private void Awake()
    {
        if (persistentObject == null)
        {
            persistentObject = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

