using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer {

    public enum STATE
    {
        IDLE, RUN, FINISHED
    }
    public STATE state;

    public float duration = 1.0f;   //计算的时间

    public float elapsedTime = 0; //流逝的时间

    public void Tick()
    {
        switch (state)
        {
            case STATE.IDLE:
                break;
            case STATE.RUN:
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= duration)
                {
                    state = STATE.FINISHED;
                }
                break;
            case STATE.FINISHED:
                break;
            default:
                Debug.LogError("MyTimer error.");
                break;
        }
    }

    public void Go()
    {
        elapsedTime = 0;
        state = STATE.RUN;
    }
}
