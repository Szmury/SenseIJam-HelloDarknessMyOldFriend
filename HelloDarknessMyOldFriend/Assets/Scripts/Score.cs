using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text gameOverText;

    int playerScore = 0;

    public static Score score;

    private void Awake()
    {
        score = this;
    }

    public void Start()
    {
        gameOverText.gameObject.SetActive(false);
        scoreText.text = "Punkty: " + playerScore.ToString();
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = "Punkty: " + playerScore.ToString();
    }

    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over. Your score: " + playerScore.ToString();
    }
}
