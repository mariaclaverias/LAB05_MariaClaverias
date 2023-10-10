using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSelection", menuName = "ScriptableObject/Player/CharacterSelection", order = 3)]
public class CharacterSelection : ScriptableObject
{
    public float life;
    public float speed;
    public GameObject skin;

    public void NaveSelection(Nave nave)
    {
        life = nave.life;
        speed = nave.speed;
        skin = nave.skin;

        Debug.Log(life + " " + speed);
    }
}
