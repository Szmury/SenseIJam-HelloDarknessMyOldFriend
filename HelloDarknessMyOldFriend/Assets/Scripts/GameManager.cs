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

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
