using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    private float timePassed = 0;
    public float finalTime = 0;
    private Action onTick = null;
    private bool isStarted = false;
    PeriodicallTicker ticker;

    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;
    public Animator animator;
    AnimatorController ani;

    void Start()
    {
        ani = getComompoent< AnimatorController> //new ();
    }    
        // Update is called once per frame
    void Update()
    {
  
        timePassed += Time.deltaTime;

        if (timePassed >= finalTime)
        {
            timePassed = 0;
            SetTickerAndCallback(5);
        }
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
        
        
        
        this.finalTime = finallTime;
        this.onTick = onTick;
        isStarted = true;
    }
}
