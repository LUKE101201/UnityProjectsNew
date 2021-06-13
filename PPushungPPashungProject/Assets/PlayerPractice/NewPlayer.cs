using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{



    public bool isLookingLeft = false;

    public Animator AM;
    public SpriteRenderer SR;
    public Rigidbody2D R2D;



    public float moveForceX = 0;
    public float jumpForce = 0;
    public bool jumpFlag = false;

    public bool isDead = false;
    public bool isMoving = false;
    public bool Walk = false;
    public bool WalkFlag = false;



    // Start is called before the first frame update
    void Start()
    {
        AM = GetComponent<Animator>();
        R2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {

        if (isDead == true) { return; }

        AM.SetBool("jumpFlag", jumpFlag);
        AM.SetBool("deadFlag", isDead);
        AM.SetBool("walkFlag", WalkFlag);




        SR.flipX = isLookingLeft;

        if (Input.GetKey(KeyCode.A))
        {
            R2D.AddForce(new Vector2(-moveForceX * Time.deltaTime, 0));
            isLookingLeft = true;
            WalkFlag = true;
            Walk = true;
        }
        else
        {
            Walk = false;
        }

        if (Walk == false)
        {
            WalkFlag = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            R2D.AddForce(new Vector2(moveForceX * Time.deltaTime, 0));
            isLookingLeft = false;
            WalkFlag = true;
            Walk = true;
        }
        else
        {
            Walk = false;
        }



        if (Input.GetKeyDown(KeyCode.Space) == true && jumpFlag == false)
        {
            R2D.AddForce(new Vector2(0, jumpForce));
            jumpFlag = true;
        }
    }



    void OnCollisionEnter2D(Collision2D coll)
    {

        if (jumpFlag == true)
        {
            jumpFlag = false;
        }

        if (coll.gameObject.CompareTag("Kill"))
        {
            isDead = true;
        }

    }



}
