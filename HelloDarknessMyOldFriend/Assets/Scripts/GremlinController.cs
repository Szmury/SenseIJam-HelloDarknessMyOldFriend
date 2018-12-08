using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinController : MonoBehaviour {

    public Action<GameObject> ToPool;
    public Action<GameObject> DeleteFromList;
    public GameObject particle;
    private float delay=3f;

    public void Burn()
    {
        Debug.Log("I'm burning!");
        //Usuni�cie z listy
        DeleteFromList(gameObject);
        StartCoroutine(Death());
    }
    
    IEnumerator Death()
    {
        ParticleSystem part = particle.GetComponent<ParticleSystem>();
        particle.SetActive(true);
        part.Play();
        delay = part.main.duration;
        yield return new WaitForSeconds(delay);
        part.Stop();
        particle.SetActive(false);
        // Dodanie do puli
        ToPool(gameObject);
        Score.score.AddScore();
        gameObject.SetActive(false);
    }
    

}
