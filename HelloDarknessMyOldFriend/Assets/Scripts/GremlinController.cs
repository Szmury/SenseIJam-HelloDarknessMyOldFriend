using System;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : MonoBehaviour {

    public Action<GameObject> ToPool;

	public void Burn()
    {
        Debug.Log("I'm burning!");
        // Start animations here
    }

    public void Death()
    {
        ToPool(gameObject);
        gameObject.SetActive(false);
    }

}
