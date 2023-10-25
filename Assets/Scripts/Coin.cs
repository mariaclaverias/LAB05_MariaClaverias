using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "ScriptableObject/Player/Coin", order = 1)]
public class Coin : ScriptableObject
{
    public float coin;

    public void AddCoin(float number)
    {
        coin += number;
        coin = Mathf.Clamp(coin, 0f, 999999f);
    }

    public void RemoveCoin(float number)
    {
        coin -= number;
        coin = Mathf.Clamp(coin, 0f, 999999f);
    }
}
