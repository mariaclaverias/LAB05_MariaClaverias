using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public Score score;

    void Update()
    {
        scoreText.text = "Score:\n" + score.score.ToString() + "\n\nHighest Score:\n" + score.highestScore.ToString();
    }
}
