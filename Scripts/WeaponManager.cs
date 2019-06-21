using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : IActorManagerInterface {

    public BoxCollider2D AttackASensor;
    public BoxCollider2D AttackBSensor;

    void Start() {
        //AttackASensor = GetComponentInChildren<BoxCollider2D>();
        AttackASensor.enabled = false;
        AttackBSensor.enabled = false;
    }

    public void SetAttackA()
    {
        AttackASensor.enabled = true;
        if (transform.DeepFind("AttackA") != null)
        {
            transform.DeepFind("AttackA").gameObject.SetActive(true);
        }
    }
    public void EndAttackA()
    {
        AttackASensor.enabled = false;
        if (transform.DeepFind("AttackA") != null)
        {
            transform.DeepFind("AttackA").gameObject.SetActive(false);
        }
    }

    public void SetAttackB()
    {
        AttackBSensor.enabled = true;
        transform.DeepFind("AttackB").gameObject.SetActive(true);
    }
    public void EndAttackB()
    {
        AttackBSensor.enabled = false;
        transform.DeepFind("AttackB").gameObject.SetActive(false);
    }
}
