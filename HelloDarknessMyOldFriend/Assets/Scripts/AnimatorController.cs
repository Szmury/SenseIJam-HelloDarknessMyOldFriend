using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public float animationTime = 0;
    [Range(0, 1)]
    public float newAnimationchance = 0.1f;
    PeriodicallTicker ticker;

    //Cached components
    public Animator animator;
    AnimatorController ani;

    void Start()
    {
        ani = GetComponent<AnimatorController>();
        ticker = new PeriodicallTicker();
        ticker.SetTickerAndCallback(animationTime, NewAnimation);
    }    
    /*
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= finalTime)
        {
            timePassed = 0;
            SetTickerAndCallback(5);
        }
    }*/

    void NewAnimation()
    {

    }

    public void SetTickerAndCallback(float finallTime)
    {
        animator.SetTrigger("Standart");
        int a = UnityEngine.Random.Range(0, 3);
        switch (a)
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
