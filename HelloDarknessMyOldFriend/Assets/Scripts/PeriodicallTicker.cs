using System;
using UnityEngine;

public class PeriodicallTicker : MonoBehaviour
{
    private float timePassed = 0;
    public float finalTime = 0;
    private Action onTick = null;
    private bool isStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
            return;

        timePassed += Time.deltaTime;

        if (timePassed >= finalTime)
        {
            timePassed = 0;
            onTick.Invoke();
        }
    }

    public void SetTickerAndCallback(float finallTime, Action onTick)
    {
        this.finalTime = finallTime;
        this.onTick = onTick;
        isStarted = true;
    }
}