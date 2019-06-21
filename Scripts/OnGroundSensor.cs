using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour {

    public BoxCollider2D boxCol;
    
	void FixedUpdate () {

        Collider2D[] outputCols = Physics2D.OverlapBoxAll(boxCol.transform.position - transform.up * 0.6f, boxCol.size, 0.0f, LayerMask.GetMask("Ground"));
        if (outputCols.Length != 0)
        {
            SendMessageUpwards("IsGround");
        }
        else
        {
            SendMessageUpwards("IsNotGround");
        }
    }
}
