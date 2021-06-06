using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csBullet : MonoBehaviour
{

    public GameObject BulletBoom;

    public AudioSource AS;
    public AudioClip Bulletbasasak;
    public bool BulletColl;
    public bool BulletColl2;

    public bool isDead;
    public float timer;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        AS = GameObject.Find("Spawner").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (BulletColl2 == true)
        //{
        //    if (BulletColl == true)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        if (isDead)
        {
            timer += Time.deltaTime;
        }

        if (timer > delay)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

        //AS.PlayOneShot(Bulletbasasak);
        //BulletColl = true;

        //if (coll.gameObject.CompareTag("B"))
        //{
        //    BulletColl2 = false;
        //}

        //AS.PlayOneShot(Bulletbasasak);

        if (coll.gameObject.CompareTag("B") == false)
        {
            Instantiate(BulletBoom, transform.position, Quaternion.identity);
            isDead = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = true;

            //AS.PlayOneShot(Bulletbasasak);
        }


    }




}
