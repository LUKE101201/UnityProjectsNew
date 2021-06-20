using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{



    public bool isLookingLeft = false;

    public Animator AM;
    public SpriteRenderer SR;
    public Rigidbody2D R2D;
    public Transform bulletspawnpoint;

    public GameObject Bullet_1;
    public GameObject Bullet;
    public float moveForceX = 0;
    public float jumpForce = 0;
    public bool jumpFlag = false;

    public bool isDead = false;
    public bool DK = false;
    public bool isMoving = false;



    // Start is called before the first frame update
    void Start()
    {
        AM = GetComponent<Animator>();
        R2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        bulletspawnpoint = transform.Find("bulletSpawn").GetComponent<Transform>();
        bulletspawnpoint = transform.Find("bulletSpawn_2").GetComponent<Transform>();
    }



    // Update is called once per frame
    void Update()
    {

        if (isDead == true) { AM.SetBool("deadFlag", true); return; }

        SR.flipX = isLookingLeft;
        if (Input.GetKeyDown(KeyCode.Mouse1))
            {
            GameObject TempBullet = Instantiate(Bullet, bulletspawnpoint.position, Quaternion.identity);

            }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject HitBullet = Instantiate(Bullet_1, bulletspawnpoint.position, Quaternion.identity);

        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.K))
        {
            DK = true;
        }
        else
        {
            DK = false;
        }

        AM.SetBool("DK", DK);

        if (DK == true)
        {

        }
        else
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
