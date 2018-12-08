using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    public bool runningGame = true;

    private void Awake()
    {
        if (gm != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
            Restart();
        else if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
