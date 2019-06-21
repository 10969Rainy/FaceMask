using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool isAI = false;
    
    private GameObject cam;

    void Awake () {

        if (!isAI)
        {
            cam = Camera.main.gameObject;
        }
	}
	
	void FixedUpdate () {

        if (!isAI)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, 0.1f);
        }
	}
}
