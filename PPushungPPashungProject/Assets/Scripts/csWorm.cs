using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csWorm : MonoBehaviour
{
    public float count = 0;
    public float HP = 50;
    //public Gameobject Boss_page2_1;
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
            //GameObject dd = Instantiate(Boss_page2_1,0,0)
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
