using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthOfField : MonoBehaviour {

    public GameObject playerHandle;
    public GameObject back;
    public float backSpeed;

    private Vector2 playerInitPos;
    private Vector2 backInitPos;

    void Awake () {

        playerInitPos = playerHandle.transform.position;
        backInitPos = back.transform.position;
    }
	
	void Update () {

        ScenesMove(back, backInitPos, backSpeed);
    }

    public void ScenesMove(GameObject go, Vector2 initPos, float speed)
    {
        float tempX = playerHandle.transform.position.x - playerInitPos.x;
        float tempY = playerHandle.transform.position.y - playerInitPos.y;
        float xVaule = tempX * 0.1f * speed;
        float yVaule = tempY * 0.08f;
        go.transform.position = new Vector3(initPos.x + xVaule, initPos.y + yVaule, 0);
    }
}
