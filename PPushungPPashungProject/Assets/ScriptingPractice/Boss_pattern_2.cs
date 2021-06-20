using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_pattern_2 : MonoBehaviour
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
        //transform.position = new Vector3(0,-1,-10);
        //transform.position = playerTransform.position;
        transform.position = new Vector3(playerTransform.position.x, 1, -10);
    } 

}
