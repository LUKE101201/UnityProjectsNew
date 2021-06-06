using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csBullet : MonoBehaviour
{

    public AudioSource AS;
    public AudioClip Bulletbasasak;
    public bool BulletColl;
    public bool BulletColl2;

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
            Destroy(gameObject);
            //AS.PlayOneShot(Bulletbasasak);
        }


    }




}
