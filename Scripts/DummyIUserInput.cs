using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyIUserInput : IUserInput {

    private GameObject player;

	void Start () {
        attack = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        float x = transform.position.x - player.transform.position.x;
        if (x >= 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
	}
}
