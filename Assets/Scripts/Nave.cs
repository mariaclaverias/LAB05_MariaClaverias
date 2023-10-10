using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nave", menuName = "ScriptableObject/Player/Nave", order = 2)]
public class Nave : ScriptableObject
{
    public float life;
    public float speed;
    public GameObject skin;
}
