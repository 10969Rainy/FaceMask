using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IUserInput {

    [Header("====== Key settings =====")]
    //键位
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public string keyA; //空格
    public string keyB; //J
    public string keyC; //K
    public string keyD; //L
    public string keyTab;
    public int mou0;
    public int mou1;
    public int mou2;

    public MyButton btnA = new MyButton();
    public MyButton btnB = new MyButton();
    public MyButton btnC = new MyButton();
    public MyButton btnD = new MyButton();
    public MyButton btnTab = new MyButton();
    public MyButton btn0 = new MyButton();
    public MyButton btn1 = new MyButton();
    public MyButton btn2 = new MyButton();
	
	void Update () {

        btnA.Tick(Input.GetKey(keyA));
        btnB.Tick(Input.GetKey(keyB));
        btnC.Tick(Input.GetKey(keyC));
        btnD.Tick(Input.GetKey(keyD));
        btnTab.Tick(Input.GetKey(keyTab));
        btn0.Tick(Input.GetMouseButton(mou0));
        btn1.Tick(Input.GetMouseButton(mou1));
        btn2.Tick(Input.GetMouseButton(mou2));

        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0.0f) - (Input.GetKey(keyDown) ? 1.0f : 0.0f);
        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0.0f) - (Input.GetKey(keyLeft) ? 1.0f : 0.0f);

        if (inputEnable == false)
        {
            targetDup = 0.0f;
            targetDright = 0.0f;
        }

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.05f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.05f);

        //Dmag = Mathf.Sqrt(Dright * Dright);
        //Dvec = Dright * transform.forward;
        UpdateDmagDvec(Dright);

        //jump = btnA.onPressed;
        jump = btnA.isDelaying && btnA.isPressing;
        airJump = btnA.onPressed;//btnA.isExtending && btnA.isPressing;

        //attack = btn0.onPressed;
        attack = btn0.onPressed;

        changeFace = btn1.isPressing;
    }
}
