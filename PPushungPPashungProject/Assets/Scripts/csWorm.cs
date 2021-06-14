using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csWorm : MonoBehaviour
{
    public float count = 0;
    public float HP = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= HP)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("B"))
        {
            // 효과는 알아서
            count++;
        }
    }
}
