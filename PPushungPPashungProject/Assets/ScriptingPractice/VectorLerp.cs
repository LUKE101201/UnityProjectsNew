using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLerp : MonoBehaviour
{

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Lerp(transform.position, playerTransform.position, Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime);
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float position)
    {
        if (position < 0) position = 0;
        if (position > 1) position = 1;

        return (start + (end - start) * position);
    }

}
