using UnityEngine;

public class MetaCollider : MonoBehaviour {

    [SerializeField]
    GameObject WinUI;

    private void Start()
    {
        WinUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        WinUI.SetActive(true);
        GameManager.gm.runningGame = false;
    }

    public void ChangeScene()
    {
        GameManager.gm.ChangeScene();
    }
}
