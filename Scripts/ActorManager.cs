using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour {

    public ActorController ac;

    [Header("=== Auto Generate if null ===")]
    public BattleManager bm;
    public WeaponManager wm;
    public StateManager sm;
    
	void Awake () {
        ac = GetComponent<ActorController>();
        GameObject model = ac.model;
        GameObject sensor = transform.Find("Sensor").gameObject;

        bm = Bind<BattleManager>(sensor);           //bm绑于sensor上
        wm = Bind<WeaponManager>(model);        //wm绑于model上
        sm = Bind<StateManager>(gameObject);    //sm绑于自身物体上
	}

    //泛型方法   T : 一个类    where T : 这个类以及他的子类
    private T Bind<T>(GameObject go) where T : IActorManagerInterface {
        T tempInstance;
        tempInstance = go.GetComponent<T>();
        if (tempInstance == null)
        {
            tempInstance = go.AddComponent<T>();
        }
        tempInstance.am = this;
        return tempInstance;
    }

    //造成伤害的方法
    public void TryDoDamage() {
        if (sm.HP > 0) {
            sm.AddHP(-5);
        }
    }

    public void Hit() {
        //受击时画面停顿
        Time.timeScale = 0.65f;
        ac.IssueTrigger("hit");
    }

    public void Die() {
        ac.IssueTrigger("die");
        ac.pi.inputEnable = false;
    }
}
