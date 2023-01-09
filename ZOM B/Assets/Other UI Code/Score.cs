using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   // Update is called once per frame

    public Text ScoreText;
    public int score = 0;

    public void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score:" + score;
    }

    public void Update()
    {
        UpdateScore();
    }

}