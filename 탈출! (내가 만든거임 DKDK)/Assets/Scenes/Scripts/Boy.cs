using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public float speedX = 0;
    public float maxSpeedX = 0;

    public float jumpForce = 0;
    public bool jumpFlag = false;

    public Animator AM;

    public string upAnimation;
    public string downAnimation;
    public string leftAnimation;
    public string rightAnimation;

    public string currentAnimation;

    void Start()
    {
        AM = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKey("w") == true)
        {
            currentAnimation = upAnimation;
            AM.SetBool("W", true);
        } 
        else
        {
            AM.SetBool("W", false);
        }

        if (Input.GetKey("a") == true)
        {
            currentAnimation = leftAnimation;
            AM.SetBool("A", true);
        }
        else
        {
            AM.SetBool("A", false);
        }

        if (Input.GetKey("s") == true)
        {
            currentAnimation = downAnimation;
            AM.SetBool("S", true);
        }
        else
        {
            AM.SetBool("S", false);
        }

        if (Input.GetKey("d") == true)
        {
            currentAnimation = rightAnimation;
            AM.SetBool("D", true);
        }
        else
        {
            AM.SetBool("D", false);
        }

        // 건너뛰고 애니메이션 플레이
        AM.Play(currentAnimation);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

    }
}
