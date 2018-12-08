using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gremlin")
        {
            Debug.Log("Gremlin in light range!");
            other.gameObject.GetComponent<GremlinController>().Burn();
        }
    }
}
