using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

    public float delay=1f;

    public GameObject lightL;
    public GameObject lightR;
    private float nextTime;

    // Use this for initialization
    void Start () {
        nextTime = Time.time + delay;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= nextTime)
        {
            nextTime = Time.time + delay;
            if(lightL.activeInHierarchy)
            {
                lightL.SetActive(false);
                lightR.SetActive(false);
            }
            else
            {
                lightL.SetActive(true);
                lightR.SetActive(true);
            }
        }
	}
}
