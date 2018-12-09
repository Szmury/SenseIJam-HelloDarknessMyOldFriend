using UnityEngine;

public class MenuScript : MonoBehaviour {

    [SerializeField]
    GameObject credits;

    private void Start()
    {
        credits.SetActive(false);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }
    
    public void HideCredits()
    {
        credits.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.gm.NextScene();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
