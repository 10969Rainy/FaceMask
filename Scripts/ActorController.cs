using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour {

    public GameObject model;
    public GameObject faceWheel;
    public IUserInput pi;
    public float walkSpeed;
    public float jumpVelocity;

    //摩擦力设置
    [Header("===== FrictionSetting =====")]
    public PhysicsMaterial2D frictionOne;
    public PhysicsMaterial2D frictionZero;
    
    private Animator anim;
    private Rigidbody2D rigid2D;
    private Vector2 planarVec;
    private Vector2 thrustVec;

    public bool lockPlanar;

    private CapsuleCollider2D col;

    //private MyTimer timer = new MyTimer();

    // Use this for initialization
    void Awake () {

        faceWheel.SetActive(false);
        pi = GetComponent<IUserInput>();
        anim = model.GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("forward", pi.Dmag);  // 1walk、0idle

        if (pi.jump)
        {
            anim.SetTrigger("jump");

            //timer.state = MyTimer.STATE.RUN;
            //timer.Tick();
        }

        if (pi.airJump)
        {
            anim.SetTrigger("airJump");
        }

        if (pi.attack)
        {
            anim.SetTrigger("attack");
        }

        if (pi.Dmag > 0.1f)
        {
            model.transform.forward = -pi.Dvec;
        }

        if (lockPlanar == false)
        {
            planarVec = pi.Dmag * -model.transform.right * walkSpeed;
        }

        if (pi.changeFace)
        {
            faceWheel.SetActive(true);
            Time.timeScale = 0.2f;
        }
        else
        {
            faceWheel.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}

    void FixedUpdate() {

        //rigid2D.position += planarVec * Time.fixedDeltaTime;

        rigid2D.velocity = new Vector2(planarVec.x, rigid2D.velocity.y) + (thrustVec);
        thrustVec = Vector2.zero;
    }

    // 通过  SendMessage 传递的信息
    ///
    /// Message pressing block 
    /// 
    //

    //在地面上时
    public void IsGround()
    {
        anim.SetBool("isGround", true);
    }
    //不在地面上时
    public void IsNotGround()
    {
        anim.SetBool("isGround", false);
        //thrustVec = new Vector2(0.0f, 0.0f);
    }

    // 动画状态机的信息
    ///
    /// FSM Enter || Update || Exit
    ///

    //跳跃动画进入时
    public void OnJumpEnter()
    {
        //在空中不能运动
        //pi.inputEnable = false;
        //lockPlanar = true;

        thrustVec = new Vector2(0.0f, jumpVelocity);
    }

    public void OnAirJumpEnter()
    {
        thrustVec = new Vector2(0.0f, jumpVelocity * 0.5f);
    }

    //掉落动画进入时
    public void OnFallEnter()
    {
        //在空中不能运动
        //pi.inputEnable = false;
        //lockPlanar = true;
    }

    //到地面上时
    public void OnGroundEnter()
    {
        pi.inputEnable = true;
        lockPlanar = false;
        col.sharedMaterial = frictionOne;
        //timer.elapsedTime = 0;
    }
    //离开地面时
    public void OnGroundExit()
    {
        col.sharedMaterial = frictionZero;
    }

    //设置Attack动画层的权重
    public void OnAttack1hAEnter()
    {
        pi.inputEnable = false;
        anim.SetLayerWeight(anim.GetLayerIndex("attack"), 1.0f);
    }
    public void OnAttack1hAUpdate()
    {
        thrustVec = new Vector2(0.2f * model.transform.right.x, 0);
    }
    //public void OnAttack1hAExit()
    //{
    //    transform.DeepFind("attackA").gameObject.SetActive(false);
    //}

    public void OnAttack1hBEnter()
    {
        pi.inputEnable = false;
        anim.SetLayerWeight(anim.GetLayerIndex("attack"), 1.0f);
    }

    public void OnAttackIdleEnter()
    {
        pi.inputEnable = true;
        anim.SetLayerWeight(anim.GetLayerIndex("attack"), 0.0f);
    }
    
    //防御状态
    //public void OnDefenseEnter()
    //{
    //    anim.SetLayerWeight(anim.GetLayerIndex("defense"), 1.0f);
    //}
    //public void OnDefenseUpdate()
    //{
    //    pi.inputEnable = false;
    //}
    //public void OnDefenseExit()
    //{
    //    pi.inputEnable = true;
    //    anim.SetLayerWeight(anim.GetLayerIndex("defense"), 0.0f);
    //}

    //受击状态
    public void OnHitEnter()
    {
        pi.inputEnable = false;
    }
    public void OnHitUpdate()
    {
        //画面停顿恢复正常
        Time.timeScale = 1.0f;
    }
    public void OnHitExit()
    {
    }

    //SetTrigger方法
    public void IssueTrigger(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }
}
