using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    public BoxCollider2D boxCol;
    public SpriteRenderer player;
    public Sprite[] attacks;

    private IUserInput pi;

    private Vector3 offset;
    
    void Awake() {
        pi = GetComponent<IUserInput>();
    }

	void Start () {

        offset = new Vector3(0.5f, 0.0f, 0.0f);
	}
	
	void FixedUpdate() {

        if (player.sprite == attacks[0] || player.sprite == attacks[1] || player.sprite == attacks[2])
        {
            Collider2D col = Physics2D.OverlapBox(boxCol.transform.position, boxCol.size, 0.0f, LayerMask.GetMask(tag == "Enemy" ? "Player" : "Enemy"));
            if (col != null)
            {
                //boxCol.enabled = true;
                //Time.timeScale = 0.25f;
                print(col.name);
            }
            else
            {
                //boxCol.enabled = false;
            }
        }
        //Time.timeScale = 1.0f;
    }
}
