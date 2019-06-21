using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState {

    private List<Transform> path = new List<Transform>();
    private int index = 0;

    private Transform playerTransform;

    //构造函数
    public PatrolState(FSMSystem fsm) : base (fsm) {

        stateID = StateID.Patrol;

        Transform pathTransform = GameObject.Find("Path").GetComponent<Transform>();
        Transform[] children = pathTransform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child != pathTransform)
            {
                path.Add(child);
            }
        }

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Act(GameObject npc) {
        npc.transform.LookAt(path[index].position);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * 2.0f);
        if (Vector3.Distance(npc.transform.position, path[index].position) < 0.5f)
        {
            index++;
            index %= path.Count;
        }
    }

    public override void Reason(GameObject npc) {
        if (Vector3.Distance(npc.transform.position, playerTransform.position) < 5.0f)
        {
            fsm.PerformTransition(Transition.SeePlayer);
        }
    }
}
