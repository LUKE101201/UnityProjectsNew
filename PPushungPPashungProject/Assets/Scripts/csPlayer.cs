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
	
    public float speedX = 0;
    public float maxSpeedX = 0;
	
    public float jumpForce = 0;
    public bool jumpFlag = false;

    public Rigidbody2D R2D;
    public AudioSource AS;
	
    public AudioClip jumpSound;
    public AudioClip dropSound;



    void Start()
    {
        R2D = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        R2D.freezeRotation = true;
    }



    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
            speedX = -maxSpeedX;
            isLookingLeft = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
            speedX = maxSpeedX;
            isLookingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpFlag == false)
        {
            R2D.AddForce(new Vector2(0, jumpForce));
            AS.PlayOneShot(jumpSound);
            jumpFlag = true;
        }
		
    }
	
	
    void OnCollisionEnter2D(Collision2D coll)
    {
		
            if (coll.gameObject.CompareTag("Floor") == true)
            {
                AS.PlayOneShot(dropSound);
                jumpFlag = false;
            }
            
    }
	


}
