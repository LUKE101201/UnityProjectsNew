using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public float Downcount;
    public bool Downscene;
    public float speedX;
    public float maxSpeedX;
    public float jumpForce;
    public bool jumpFlag;
    public Rigidbody2D R2D;
    public Transform BalloonTransform;
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
        Rigidbody2D asd = GameObject.Find("balloon_0").GetComponent<Rigidbody2D>();
        R2D = asd;
        BalloonTransform = GameObject.Find("balloon_0").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            BalloonTransform.Translate(speedX * Time.deltaTime, 0, 0);
            speedX = -maxSpeedX;
        }

        if (Input.GetKey("d"))
        {
            BalloonTransform.Translate(speedX * Time.deltaTime, 0, 0);
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
        GameObject targetGameObject = coll.gameObject;

        if (targetGameObject.CompareTag("1Scene") == true)
        {
            Nextscene();
        }

        if (targetGameObject.CompareTag("Floor"))
        {
            jumpFlag = false;
        }
    }
}
