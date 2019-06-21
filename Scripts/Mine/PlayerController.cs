using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 8.0f;
    public float jumpHeight = 8.0f;

    //public GameObject weaponWheel;
    public Transform cam;
    private Vector3 offset;

    private Vector3 movePos;

    public GameObject wind;
    public GameObject fireBall1;
    public GameObject fireBall2;

    private Rigidbody2D rb2d;
    private Animator ac;

    private Vector3 safePos = Vector3.zero;

    private float timer = 0;

    private bool jump = false;
    private bool isGround = true;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ac = GetComponent<Animator>();
        offset = cam.position - transform.position;
	}
	
	void Update () {
        
        cam.position = offset + transform.position;

        movePos.x = Input.GetAxis("Horizontal");

        //rb2d.velocity = new Vector3(movePos.x, rb2d.velocity.y, 0) * speed;

        //jump = Input.GetKeyDown(KeyCode.Space);

        //if (jump && isGround)
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        //}

        //print(rb2d.velocity.y);


        //if (!isGround)
        //{
        //    movePos.y -= 9.8f * Time.deltaTime;
        //}

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 100.0f);
        if (hit.collider != null)
        {
            print(hit.collider.name);
        }

        if (!movePos.x.Equals(0))
        {
            rb2d.velocity = new Vector2(movePos.x * speed, rb2d.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb2d.velocity.y.Equals(0))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                //ac.SetBool("Jump", true);
            }
        }

        if (isGround)
        {
            //ac.SetBool("Jump", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            ac.SetBool("Attack", true);
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                ac.SetBool("Attack", false);
                timer = 0.0f;
            }
        }

        if (movePos.x > 0)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            ac.SetBool("Walk", true);
        }
        else if (movePos.x < 0)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            ac.SetBool("Walk", true);
        }
        else
        {
            ac.SetBool("Walk", false);
        }

        //if (Input.GetKey(KeyCode.Tab))
        //{
        //    weaponWheel.SetActive(true);
        //    Time.timeScale = 0.1f;
        //}
        //else
        //{
        //    weaponWheel.SetActive(false);
        //    Time.timeScale = 1.0f;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TriggerManager>().type == Type.Safe)
        {
            safePos = other.transform.position;
        }

        if (other.gameObject.GetComponent<TriggerManager>().type == Type.Unsafe)
        {
            transform.position = safePos;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
