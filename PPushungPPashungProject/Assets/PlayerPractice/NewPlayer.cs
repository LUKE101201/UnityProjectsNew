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

        if (isDead == true) { AM.SetBool("deadFlag", true); return; }

        SR.flipX = isLookingLeft;

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            isMoving = false;
        }
        else
        if (Input.GetKey(KeyCode.A))
        {
            R2D.AddForce(new Vector2(-moveForceX * Time.deltaTime, 0));
            isLookingLeft = true;
            isMoving = true;
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            R2D.AddForce(new Vector2(moveForceX * Time.deltaTime, 0));
            isLookingLeft = false;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && jumpFlag == false)
        {
            R2D.AddForce(new Vector2(0, jumpForce));
            jumpFlag = true;
        }

        AM.SetBool("jumpFlag", jumpFlag);
        AM.SetBool("walkFlag", isMoving);

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
