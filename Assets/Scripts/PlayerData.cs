using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public CharacterSelection character;

    private float life;
    public float speed;
    private GameObject skin;

    public Slider slider;
    public Score score;
    public TMP_Text scoreText;

    void Awake()
    {
        score.score = 0f;

        life = character.life;
        speed = character.speed;
        skin = character.skin;
    }

    void Start()
    {
        life = character.life;
        Instantiate(skin, transform.position, skin.transform.rotation, transform);
    }

    void Update()
    {
        UpdateLife();
        UpdateScore();

        score.ScoreForTime();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Alien" ||
            other.gameObject.tag == "Trash")
        {
            Destroy(other.gameObject);
            RemoveLife();

            if (life == 0f)
            {
                score.HighestScore();
                SceneManager.LoadScene("Score");
            }
        }
    }

    void UpdateLife()
    {
        slider.value = (life / character.life) * 100;
    }

    void UpdateScore()
    {
        scoreText.text = score.score.ToString();
    }

    void AddLife()
    {
        life++;
        life = Mathf.Clamp(life, 0, character.life);
    }

    void RemoveLife()
    {
        life--;
        life = Mathf.Clamp(life, 0, character.life);
    }
}
