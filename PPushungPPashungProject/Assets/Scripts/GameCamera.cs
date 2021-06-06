using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    public float currentCameraY;

    public Vector3 magnitude;

    public float shakeTimer = 0;



    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {


        if (shakeTimer > 0)
        {
            magnitude = new Vector3(Random.Range(-shakeTimer, shakeTimer), Random.Range(-shakeTimer, shakeTimer));
            shakeTimer -= Time.deltaTime;
        }

        transform.position = new Vector3(magnitude.x, currentCameraY + magnitude.y, -10);


    }

    public void Shake(float time)
    {
        shakeTimer += time;
    }
}
