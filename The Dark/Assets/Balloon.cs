using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    public float Downcount;
    public bool Downscene;
    public float speedX;
    public float maxSpeedX;
    public float jumpForce;
    public bool jumpFlag;
    public Rigidbody2D R2D;
    public AudioSource AS;



    public AudioClip jumpSound;
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    //public AudioClip 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
            speedX = -maxSpeedX;
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
            speedX = maxSpeedX;
        }

        if (Input.GetKey("space") && jumpFlag == false)
        {
            R2D.AddForce(new Vector2(0, jumpForce));
            AS.PlayOneShot(jumpSound);
            jumpFlag = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

    }

    void Nextscene()
    {
        SceneManager.LoadScene("1stage");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("1Scene") == true)
        {
            Nextscene();
        }

        if (coll.gameObject.CompareTag("Floor"))
        {
            jumpFlag = false;

        }
    }
}
