using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : IActorManagerInterface {

    public float HPMax = 30.0f;
    public float HP = 15.0f;

    private Animator camAnim;

    void Start() {
        camAnim = Camera.main.gameObject.GetComponent<Animator>();
    }

	public void AddHP(float value) {
        HP += value;
        HP = Mathf.Clamp(HP, 0, HPMax);
        if (HP > 0)
        {
            //如果hp大于0，执行hit逻辑
            Vector3 y = transform.rotation.y == 0 ? new Vector3(-0.3f, 0.1f, 0.0f) : new Vector3(0.3f, 0.1f, 0.0f);
            transform.position += y;
            camAnim.SetTrigger("hit");
            am.Hit();
        }
        else
        {
            //如果hp小于 等于0，执行die逻辑
            am.Die();
        }
    }
}