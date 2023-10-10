using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text[] scoreText;
    public Score score;

    void Update()
    {
        scoreText[0].text = score.score.ToString();
        scoreText[1].text = score.highestScore.ToString();
    }
}
