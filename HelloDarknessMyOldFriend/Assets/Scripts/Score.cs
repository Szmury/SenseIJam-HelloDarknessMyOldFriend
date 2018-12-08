using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int maxHealth;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text negativeScoreText;
    [SerializeField]
    Text gameOverText;

    int playerScore;

    public static Score score;

    private void Awake()
    {
        score = this;
    }

    public void Start()
    {
        playerScore = maxHealth;
        gameOverText.gameObject.SetActive(false);
        scoreText.text = maxHealth.ToString();
        negativeScoreText.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        playerScore--;
        if(playerScore <= 0)
        {
            scoreText.gameObject.SetActive(false);
            negativeScoreText.gameObject.SetActive(true);
            negativeScoreText.text = playerScore.ToString();
            return;
        }
        scoreText.text = playerScore.ToString();
    }

    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over.\nYou lost " + (maxHealth - playerScore).ToString() + " gremlins";
    }
}
