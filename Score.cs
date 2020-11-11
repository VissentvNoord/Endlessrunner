using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public int highScore;
    public Text highScoreText;

    private Rigidbody rb;

    float timer;
    public float delayAmount = 1;

    float deathTime;
    public float deathDelay = 1;

    public GameManager gameManager;
     
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Time.timeScale = 0;

        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        highScoreText.text = highScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            Time.timeScale = 1;
        }

        AddScore();
        ChangeHighScore();
        GameOver();
    }

    void AddScore()
    {
        if (rb.velocity.x >= 0.1)
        {
            timer += Time.deltaTime;
            if (timer >= delayAmount)
            {
                score++;
                scoreText.text = score.ToString();
                timer = 0;
            }
        }
    }

    void ChangeHighScore()
    {
        if(score > highScore)
        {
            highScore = score;

            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    void GameOver()
    {
            if (rb.velocity.x < 0.1)
            {
            deathTime += Time.deltaTime;
                    if(deathTime >= deathDelay)
                    {
                         gameManager.ResetGame();
                    }
            }

            if(rb.velocity.x >= 1)
        {
            deathTime = 0;
        }
    }
}
