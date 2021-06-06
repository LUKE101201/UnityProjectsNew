using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public float randomRange = 0;
    public Vector3 magnitude;

    public Vector3 originalPosition;

    public float height;

    public float count;
    private float upspeed = 3f;
    private float maxcount = 3;
    public bool flipFlag;

    public bool FixUpDownFlag = false;



    // Start is called before the first frame update
    void Start()
    {
        //originalPosition = GetComponent<Transform>().position;
        originalPosition = transform.position; // ¶È°°À½!
    }

    // Update is called once per frame
    void Update()
    {


        if (flipFlag == false)
        {
            height += upspeed * Time.deltaTime;
        }
        else
        {
            height += -upspeed * Time.deltaTime;
        }

        count += Time.deltaTime;

        magnitude = new Vector3(Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange));

        if (!FixUpDownFlag)
        {
            transform.position = new Vector2(originalPosition.x + magnitude.x, originalPosition.y + height + magnitude.y);
        }
        else
        {
            transform.position = new Vector2(originalPosition.x + magnitude.x, originalPosition.y + magnitude.y);
        }


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
