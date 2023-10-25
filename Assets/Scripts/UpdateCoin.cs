using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoin : MonoBehaviour
{
    public TMP_Text[] coinText;
    public Coin coin;

    void Update()
    {
        coinText[0].text = coin.coin.ToString();
    }
}
