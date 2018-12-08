using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int maxHealth;
    [SerializeField]
    Text scoreText;
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
    }

    public void AddScore()
    {
        playerScore--;
        if(playerScore <= 0)
        {
            GameOver();
            GameManager.gm.runningGame = false;
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
