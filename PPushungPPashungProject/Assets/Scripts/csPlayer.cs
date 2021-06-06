/*
 *  Spring 2021
 *  Unity 2D Game Project
 *  Written by SeungGeon Kim & DongKyu Kim
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool main = true;
    public bool main1 = true;
    public float killTimer;
    public float UpForce;
    public float killDelay;
    public bool mainsoundgo;
    public bool mainsoundgo1;
    public GameObject Bullet;
    public Transform RightBulletSpawnPoint;
    public Transform LeftBulletSpawnPoint;
    public AudioClip mainsound;
    public AudioClip forestsound;



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



    // Average(0, 1, 2, 4, -1, 3);

    double Average(params int[] args)
    {
        int count = args.Length;

        int sum = 0;

        for (int i = 0; i < count; i++)
        {
            sum += args[i];
        }
            
        return sum / count;
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

            if (Input.GetKey(KeyCode.Mouse1))
            {
                // Instantiate 사용법 : Instantiate(소환할거 (GameObject), 위치 (Vector3), Quaternion (그냥 아래꺼 쓰면 됨))
                GameObject newBullet = Instantiate(Bullet, RightBulletSpawnPoint.position, Quaternion.identity);
                Rigidbody2D BulletRG = newBullet.GetComponent<Rigidbody2D>();
                BulletRG.AddForce(Vector2.right * shootForce);
                BulletRG.AddForce(Vector2.up * UpForce);
                AudioSource BulletAD;
                BulletAD = GameObject.Find("Spawner").GetComponent<AudioSource>();
                Debug.Log(BulletAD.volume);
                string BulletMsg = "leftShoot!";
                Debug.Log(BulletMsg);
               

            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject newBullet = Instantiate(Bullet, LeftBulletSpawnPoint.position, Quaternion.identity);
                Rigidbody2D newR2D = newBullet.GetComponent<Rigidbody2D>();
                newR2D.AddForce(Vector2.left * shootForce);
                newR2D.AddForce(Vector2.up * UpForce);
                //newR2D.gravityScale = Random.Range(100,300);
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
            if (main == true)
            {
                if (SceneManager.GetActiveScene().name == "1stage" && (mainsoundgo = true))
                {
                    AS.PlayOneShot(mainsound);
                    mainsoundgo = false;
                    main = false;
                }
            }

            if (main1 == true)
            {
                if (SceneManager.GetActiveScene().name == "Foreststage" && (mainsoundgo1 = true))
                {
                    AS.PlayOneShot(forestsound);
                    mainsoundgo1 = false;
                    main1 = false;
                }
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
            // transform.Rotate(Vector3.forward * 90); // 옆으로 눕게
            // Destroy(this.GetComponent<GameObject>());
            // this.GetComponent<Transform>() = transform
        }

        if (coll.gameObject.CompareTag("Nextstage"))
        {
            SceneManager.LoadScene("1stage");
        }

        if (coll.gameObject.CompareTag("Forest"))
        {
            SceneManager.LoadScene("Foreststage");
        }

        
    }

    

        void OnTriggerEnter2D(Collider2D coll)
    {

       

    }



}
