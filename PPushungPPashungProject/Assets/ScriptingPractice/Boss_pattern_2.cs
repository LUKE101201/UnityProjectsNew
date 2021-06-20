using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_pattern_2 : MonoBehaviour
{
    public float patten;
    public float count;
    public float maxcount;
    public Transform playerTransform;
    public GameObject Bird;
    public Transform birdspawn;


    // Start is called before the first frame update
    void Start()
    {
       playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       birdspawn = transform.Find("birdspawn").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (patten == 0 && count >= maxcount)
        {
            patten = Random.Range(1, 3);
        }

        if (patten == 2)
        {
            patten = 1;
        }

        if (patten == 3)
        {
              patten = 1;
        }



            if (patten == 1)
        {
            GameObject bird = Instantiate(Bird, birdspawn.position, Quaternion.identity);
            patten = 0;
            count = 0;
        }
        
    }

    private void FixedUpdate()
    {
        count++;
    }

}
