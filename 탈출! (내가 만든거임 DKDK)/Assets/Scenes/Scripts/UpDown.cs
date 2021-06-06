using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float count;
    private float upspeed = 3f;
    private float maxcount = 3;
    public bool flipFlag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (flipFlag == false)
        {
            transform.Translate(0,upspeed * Time.deltaTime,0);
        }
        else
        {
            transform.Translate(0,-upspeed * Time.deltaTime,0);
        }

        count += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (count >= maxcount)
        {
            flipFlag = !flipFlag;
            count = 0;
        }
    }
}

