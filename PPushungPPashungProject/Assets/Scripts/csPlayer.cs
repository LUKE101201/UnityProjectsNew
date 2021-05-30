/*
 *  Spring 2021
 *  Unity 2D Game Project
 *  Written by SeungGeon Kim & DongKyu Kim
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour
{



    public bool isLookingLeft;
	
    //public float speedX = 0;
    public float moveForceX = 0;
	
    public float jumpForce = 0;
    public float shootForce = 0;
    // true -> jumping
    public bool jumpFlag = false;

    public Animator AM;
    public Rigidbody2D R2D;
    public AudioSource AS;
    public SpriteRenderer SR;
	
    public AudioClip jumpSound;
    public AudioClip dropSound;
    public AudioClip killSound;

    public bool isDead;
    public float killTimer;
    public float killDelay;

    public GameObject Bullet;
    public Transform RightBulletSpawnPoint;
    public Transform LeftBulletSpawnPoint;



    void Start()
    {
        AM = GetComponent<Animator>();
        R2D = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();

        RightBulletSpawnPoint = transform.Find("RightBulletSpawnPoint");
        LeftBulletSpawnPoint = transform.Find("LeftBulletSpawnPoint");

        R2D.freezeRotation = true;
        // Disable jumping on start
        jumpFlag = true;
	}
    


    bool IsMoving()
    {
        return (R2D.velocity.sqrMagnitude > 1.0f);
    }



    void Update()
    {
        AM.SetBool("dead", isDead);
        AM.SetBool("walking", IsMoving());
        AM.SetBool("jumping", jumpFlag);

        if (isDead)
        {
            killTimer += Time.deltaTime;
            if (killTimer >= killDelay)
            {
                Destroy(gameObject);
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (isLookingLeft == false)
                {
                    // Instantiate ���� : Instantiate(��ȯ�Ұ� (GameObject), ��ġ (Vector3), Quaternion (�׳� �Ʒ��� ���� ��))
                    GameObject newBullet = Instantiate(Bullet, RightBulletSpawnPoint.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce);
                }
                else
                {
                    GameObject newBullet = Instantiate(Bullet, LeftBulletSpawnPoint.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * shootForce);
                }
            }

            SR.flipX = isLookingLeft;

            if (Input.GetKey(KeyCode.A))
            {
                R2D.AddForce(new Vector2(-moveForceX * Time.deltaTime, 0));
                isLookingLeft = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                R2D.AddForce(new Vector2(moveForceX * Time.deltaTime, 0));
                isLookingLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) == true && jumpFlag == false)
            {
                R2D.AddForce(new Vector2(0, jumpForce));
                AS.PlayOneShot(jumpSound);
                jumpFlag = true;
            }

        }
		
    }
	

	
    void OnCollisionEnter2D(Collision2D coll)
    {
		
        if (coll.gameObject.CompareTag("Floor") == true && jumpFlag == true)
        {
            AS.PlayOneShot(dropSound);
            jumpFlag = false;
        }  
        else if (coll.gameObject.CompareTag("Kill") == true && isDead == false)
        {
            AS.PlayOneShot(killSound);
            isDead = true;
            // transform.Rotate(Vector3.forward * 90); // ������ ����
            // Destroy(this.GetComponent<GameObject>());
            // this.GetComponent<Transform>() = transform
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

       

    }



}
