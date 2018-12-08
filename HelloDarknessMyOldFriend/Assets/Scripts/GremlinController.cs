using System;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : MonoBehaviour {

    public Action<GameObject> ToPool;

	public void Burn()
    {
        Debug.Log("I'm burning!");
        Death();
        // Start animations here
    }

    public void Death()
    {
        ToPool(gameObject);
        Score.score.AddScore();
        gameObject.SetActive(false);
    }

}
