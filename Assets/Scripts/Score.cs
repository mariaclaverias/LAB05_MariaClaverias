using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObject/Player/Score", order = 0)]
public class Score : ScriptableObject
{
    public float score;
    public float highestScore;
    private float startTime = 0;

    public void ScoreForTime()
    {
        startTime += Time.deltaTime;

        if (startTime > 60f)
        {
            AddScore(10f);
            startTime = 0f;
        }
    }

    public void AddScore(float number)
    {
        score += number;
        score = Mathf.Clamp(score, 0f, 999999f);
    }

    public void RemoveScore(float number)
    {
        score -= number;
        score = Mathf.Clamp(score, 0f, 999999f);
    }

    public void HighestScore()
    {
        if (score > highestScore)
        {
            highestScore = score;
        }
    }
}
