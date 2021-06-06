using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    public Transform moujaTransform;

    public float currentCameraY;

    public float mainCameraY;
    public float undergroundCameraY;

    public bool isUnderground;

    public Vector3 magnitude;

    public float shakeTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        moujaTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnderground)
        {
            currentCameraY = undergroundCameraY;
        }
        else
        {
            currentCameraY = mainCameraY;
        }


        if (shakeTimer > 0)
        {
            magnitude = new Vector3(Random.Range(-shakeTimer, shakeTimer), Random.Range(-shakeTimer, shakeTimer));
            shakeTimer -= Time.deltaTime;
        }

        transform.position = new Vector3(moujaTransform.position.x + magnitude.x, currentCameraY + magnitude.y, -10);


    }

    public void Shake(float time)
    {
        shakeTimer += time;
    }
}
