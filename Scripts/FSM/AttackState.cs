using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState {

    private Transform playerTransform;

    //构造函数
    public AttackState(FSMSystem fsm) : base(fsm) {

        stateID = StateID.Attack;

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Act(GameObject npc) {

        Debug.Log("Attack");
    }

    public override void Reason(GameObject npc) {

        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 3)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }
}
