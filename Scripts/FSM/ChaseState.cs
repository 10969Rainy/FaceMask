using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState {

    private Transform playerTransform;

    //构造函数
    public ChaseState(FSMSystem fsm) : base(fsm) {

        stateID = StateID.Chase;

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Act(GameObject npc) {

        npc.transform.LookAt(playerTransform.position);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * 8);
    }

    public override void Reason(GameObject npc) {

        if (Vector3.Distance(npc.transform.position, playerTransform.position) > 8)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }

        if (Vector3.Distance(npc.transform.position, playerTransform.position) < 2)
        {
            fsm.PerformTransition(Transition.ClosePalyer);
        }
    }
}
