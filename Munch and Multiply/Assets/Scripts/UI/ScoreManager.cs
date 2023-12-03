using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
