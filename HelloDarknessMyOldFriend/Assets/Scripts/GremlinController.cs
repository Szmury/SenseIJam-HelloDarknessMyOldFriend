using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : MonoBehaviour {

    public Action<GameObject> ToPool;
    public GameObject particle;
    private float delay=3f;


    public void Burn()
    {
        Debug.Log("I'm burning!");
        ParticleSystem part = particle.GetComponent<ParticleSystem>();
        particle.SetActive(true);
        part.Play();
        delay = part.main.duration;
        StartCoroutine(Death());
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSeconds(delay);
        particle.SetActive(false);
        ToPool(gameObject);
        Score.score.AddScore();
        gameObject.SetActive(false);
    }
    

}
