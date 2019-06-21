using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private FSMSystem fsm;

    void Start () {

        InitFSM();
	}

    //实例 FSMSystem
    void InitFSM() {

        fsm = new FSMSystem();

        //实例 FSMState
        FSMState patrolState = new PatrolState(fsm);
        FSMState chaseState = new ChaseState(fsm);
        FSMState attackState = new AttackState(fsm);

        //添加状态
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);
        fsm.AddState(attackState);

        //添加转换条件
        //Reason方法所在的状态添加转换条件
        //chaseState.AddTransition(Transition.ClosePalyer, StateID.Attack);  可以转换到攻击状态，因为转换的Reason方法在Chase状态中
        //attackState.AddTransition(Transition.ClosePalyer, StateID.Attack);  不可以转换攻击状态，因为转换的Reason方法在Chase状态中
        patrolState.AddTransition(Transition.SeePlayer, StateID.Chase);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);
        chaseState.AddTransition(Transition.ClosePalyer, StateID.Attack);
        attackState.AddTransition(Transition.LostPlayer, StateID.Chase);
    }
	
	void Update () {

        fsm.Update(gameObject);
    }
}
