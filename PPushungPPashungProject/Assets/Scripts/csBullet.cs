using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBullet : MonoBehaviour
{

    public AudioSource AS;
    public AudioClip Bulletbasasak;

    // Start is called before the first frame update
    void Start()
    {
        AS = GameObject.Find("Spawner").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Destroy(coll.gameObject);
        Destroy(gameObject);
        AS.PlayOneShot(Bulletbasasak);
    }
}
