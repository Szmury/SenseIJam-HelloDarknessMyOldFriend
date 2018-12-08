using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public float animationTime = 3;
    [Range(0, 1)]
    public float newAnimationchance = 0.1f;

    //Cached components
    public Animator animator;
    PeriodicallTicker ticker;

    void Start()
    {
        animator = GetComponent<Animator>();
        ticker = GetComponent<PeriodicallTicker>();
        ticker.SetTickerAndCallback(animationTime,Callback);
    }    

    private void Callback()
    {
        switch (UnityEngine.Random.Range(0, 3))
        { 
        case 0 :
            animator.SetTrigger("Jump");
            break;
        case 1 :
            animator.SetTrigger("Salto");
            break;
        case 2 :
            animator.SetTrigger("Shake");
            break;
        }
    }
}
