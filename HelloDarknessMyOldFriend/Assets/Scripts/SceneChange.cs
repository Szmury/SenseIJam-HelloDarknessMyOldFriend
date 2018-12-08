using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour {

    void SceneChanger(int level)
    {
        SceneManager.LoadScene("level" + level.ToString());
    }
}
