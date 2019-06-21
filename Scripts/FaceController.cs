using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceController : MonoBehaviour {

    public GameObject wood;
    public GameObject water;
    public GameObject fire;
    public GameObject elec;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeFace(Sprite img)
    {
        GetComponent<Image>().sprite = img;

        switch (img.ToString())
        {
            case "Wood (UnityEngine.Sprite)":
                wood.SetActive(true);
                break;
            case "Water (UnityEngine.Sprite)":
                water.SetActive(true);
                break;
            case "Fire (UnityEngine.Sprite)":
                fire.SetActive(true);
                break;
            case "Elec (UnityEngine.Sprite)":
                elec.SetActive(true);
                break;
            default:
                break;
        }
    }
}
