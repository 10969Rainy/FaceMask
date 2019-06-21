using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton {

    public bool isPressing = false;       //Button正在被按压
    public bool onPressed = false;       //Button刚被按压
    public bool onReleased = false;     //Button刚被释放
    public bool isExtending = false;     //Button用于双击
    public bool isDelaying = false;       //Button用于长按

    public float extendingDuration = 1.0f; //延长的时间，这段时间如果按压了按钮，为双击
    public float delayingDuration = 1.0f;  //迟滞的时间，这段时间内未释放相同按钮，为长按

    private bool curState = false;
    private bool lastState = false;

    private MyTimer extTimer = new MyTimer();
    private MyTimer delayTimer = new MyTimer();

    public void Tick(bool input) {

        extTimer.Tick();
        delayTimer.Tick();

        curState = input;

        isPressing = curState;  //按钮一直处于按压

        onPressed = false;
        onReleased = false;
        if (curState != lastState)
        {
            if (curState == true)
            {
                onPressed = true;   //按钮被按压的一瞬间
                StartTimer(delayTimer, delayingDuration);   ////按压按钮时，迟滞的时间开始计时
            }
            else
            {
                onReleased = true;  //按钮释放的一瞬间
                StartTimer(extTimer, extendingDuration);    //释放按钮时，延长的时间开始计时
            }
        }
        lastState = curState;

        isExtending = ((extTimer.state == MyTimer.STATE.RUN) ? true : false);   //处于延长的时间

        isDelaying = ((delayTimer.state == MyTimer.STATE.RUN) ? true : false);  //处于迟滞的时间
    }

    private void StartTimer(MyTimer timer, float duration)
    {
        timer.duration = duration;
        timer.Go();
    }
}
