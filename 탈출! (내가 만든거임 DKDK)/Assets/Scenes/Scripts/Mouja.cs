using UnityEngine;
using UnityEngine.SceneManagement; // 씬매니저 쓰려면 필요

public class Mouja : MonoBehaviour
{
    public float speedX = 0;
    public float maxSpeedX = 0;
    public float count;
    public float jumpForce = 500;
    public bool jumpFlag = false;
    public bool Timedash = false;
    public bool gameGo = true;
    public bool MoveWall = false;
    public bool daymusic;
    public float WallMoveSpeed = 0.005f;
    public float Maxcount = 1000;
    public float Downspeed = 0.01f;
    public bool isLookingLeft;
    public float maxcount = 1000;
    public float Timecount;
    public float Timecount2;
    public float TT = 0;
    public float TTflag = 0;
    bool isTimeSaveTriggered;
    public float PP = 0;
    public bool doorslow = false;
    public bool CoolTime;
    public float rotateSpeed = 2;
    public float DieBounce = 10000;
    bool flipFlag;
    public float upspeed = 0.01f;
    public Rigidbody2D R2D;
    public AudioSource AS;
    public SpriteRenderer SR;
    public float MMaxcount = 1000;
    public float SkillTimeMultiplier;
    public float Count = 1000;
    public AudioClip jumpSound;
    public AudioClip dropSound;
    public AudioClip keynamnam;
    public AudioClip Die;
    public AudioClip Break;
    public AudioClip Becairful;
    public AudioClip fast;
    public AudioClip down;
    public AudioClip Max;
    public AudioClip day;
    public AudioClip ghost;
    public AudioClip boss;
    public AudioClip die;
    public TrailRenderer booster;
    public GameCamera playerCamera;
    public AudioClip Door;
    public Transform missileTransform;
    public Transform specialDoorTransform;
    public Transform TextUpperTransform;
    public AudioClip doorOpenSound;
    //public AudioClip 
    //public AudioClip
    //public AudioClip
    //public AudioClip 
    //public AudioClip
    //public AudioClip
    //public AudioClip 
    //public AudioClip
    //public AudioClip
    //public AudioClip 
    //public AudioClip
    //public AudioClip

    void Start()
    {
        // 리지드바디 등록
        R2D = this.GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();
        missileTransform = GameObject.FindGameObjectWithTag("ShowGaege").GetComponent<Transform>();
        specialDoorTransform = GameObject.FindGameObjectWithTag("SpecialDoor").GetComponent<Transform>();
        TextUpperTransform = GameObject.FindGameObjectWithTag("TextUpper").GetComponent<Transform>();
        //missileTransform = GameObject.FindGameObjectWithTag("ShowGaege").transform;

        // 회전 잠금
        AS.PlayOneShot(Max);
        R2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (daymusic == false)
        {
            ChangeMusic("day");
        }
        booster = transform.Find("Trail").GetComponent<TrailRenderer>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameCamera>();
    }

    // 직접만든 함수 예시
    void ChangeMusic(string name)
    {
        if (name == "day")
        {
            AS.clip = day;
        }
        else if (name == "ghost")
        {
            AS.clip = ghost;
        } 
        else if (name == "boss")
        {
            AS.clip = boss;
        }
        else if (name == "die")
        {
            AS.clip = die;
        }

        AS.loop = true;
        AS.Play();

        //playerCamera.shakeTimer = 1;

        //playerCamera.Shake(1);
        
    }

    //float AplusB(float FIRST, float SECOND)
    //{
    //    return FIRST + SECOND + SECOND;
    //}



    void DoorOpen(float openspeed)
    {
        float yPosition = specialDoorTransform.position.y;

        // Hardcoded
        if (yPosition < 16)
        {
            specialDoorTransform.Translate(new Vector3(0, openspeed, 0));
        }

        TextUpperTransform.Translate(new Vector3(0, openspeed, 0));
    }



    void Update()
    {

        if (MoveWall)
        {
            // Hardcoded
            DoorOpen(5 * Time.deltaTime);
        }



        if (gameGo)
        {
            if (Input.GetKey("a"))
            {
                transform.Translate(speedX * Time.deltaTime, 0, 0);
                speedX = -maxSpeedX;
                isLookingLeft = true;
            }

            if (Input.GetKey("d"))
            {
                transform.Translate(speedX * Time.deltaTime, 0, 0);
                speedX = maxSpeedX;
                isLookingLeft = false;
            }

            if (Input.GetKey("space") && jumpFlag == false)
            {
                R2D.AddForce(new Vector2(0, jumpForce));
                AS.PlayOneShot(jumpSound);
                jumpFlag = true;
            }

            if (MoveWall == true)
            {
                GameObject.Find("Wall").transform.Translate(new Vector3(WallMoveSpeed * Time.deltaTime, 0, 0));
            }

            SR.flipX = isLookingLeft;

            if (isTimeSaveTriggered == true)
            {
                count++;
                if (count >= Maxcount)
                {
                    MoveWall = true;
                    isTimeSaveTriggered = false;
                }
            }


        }
        else
        {
            SR.flipY = true;

            GameObject.FindGameObjectWithTag("Restart").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("RestartShadow").GetComponent<MeshRenderer>().enabled = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("NewMainGame");
            }


        }
        //여기부터
        if(CoolTime == false)
        {
            Count+= Time.deltaTime * SkillTimeMultiplier;
            missileTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            missileTransform.localScale = new Vector3(2.0f, 2.0f);
            //this.GetComponent<Transform>().Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            missileTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            if (booster.enabled)
            {
                missileTransform.localScale = new Vector3(3f + Random.Range(0.1f,0.5f), 3f + Random.Range(0.1f, 0.5f));
            }
            else
            {
                missileTransform.localScale = new Vector3(2.5f, 2.5f);
            }
        }
        

        if (Count >= MMaxcount)
        {
            Timedash = true;
            CoolTime = true;
        }

        if (Timedash == true)
        {
            
            if (TTflag == 1)
            {
                TT = 1;
            }
            // booster on
            if (Input.GetKeyDown("f"))
            {
                booster.enabled = true;
                maxSpeedX = maxSpeedX + 2;
                Count = 0;
                PP = 1;
                Timedash = false;
                AS.PlayOneShot(fast);
                jumpFlag = false;
            }
        }
        else
        {

        }

        if (PP == 1)
        {
            Timecount2 += Time.deltaTime * SkillTimeMultiplier;
            PP = 2;
        }

        if (PP == 2)
        {
            PP = 1;
        }

        // booster off
        if (Timecount2 >= Timecount)
        {
            booster.enabled = false;
            CoolTime = false;
            maxSpeedX = maxSpeedX - 2;
            Timecount2 = 0;
            PP = 0;
            AS.PlayOneShot(down);
            TT = 0;
            TTflag = 1;
        }

        if (TT == 1)
        {
            AS.PlayOneShot(Max);
            TT = 2;
        }

        if(TT == 2)
        {
            TTflag = 0;
        }
        //여기까지
        if (doorslow == true)
        {
            maxSpeedX = maxSpeedX + 2;
            doorslow = false;
        }

        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            missileTransform.position = new Vector3(0, 100, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (gameGo == true)
        {
            if (coll.gameObject.CompareTag("Floor") == true)
            {
                AS.PlayOneShot(dropSound);
                jumpFlag = false;
                doorslow = false;
            }

            // 쉬운거 
            if (coll.gameObject.CompareTag("Key") == true)
            {
                Destroy(coll.gameObject);
                AS.PlayOneShot(keynamnam);
                ChangeMusic("ghost");
                MoveWall = true;



                // 다른기 찾아서 없애는거
                Destroy(GameObject.FindGameObjectWithTag("HardKey"));
            }

            // 어려운건
            if (coll.gameObject.CompareTag("HardKey") == true)
            {
                Destroy(coll.gameObject);
                AS.PlayOneShot(keynamnam);
                ChangeMusic("ghost");
                MoveWall = true;
                Destroy(GameObject.FindGameObjectWithTag("Key"));
            }

            if (coll.gameObject.CompareTag("Die") == true)
            {
                gameGo = false;
                MoveWall = false;
                AS.PlayOneShot(Die);
                ChangeMusic("die");
                R2D.AddForce(new Vector3(DieBounce, DieBounce, 0));
                playerCamera.Shake(0.5f);
                //transform.Translate(new Vector3(0, Dieup * Time.deltaTime, 0));
            }

            if (coll.gameObject.CompareTag("Break") == true)
            {
                Destroy(coll.gameObject);
                AS.PlayOneShot(Break);
                playerCamera.Shake(0.1f);
                jumpFlag = false;
            }

            if (coll.gameObject.CompareTag("TimeBreak") == true)
            {
                jumpFlag = false;
                Destroy(coll.gameObject);
                AS.PlayOneShot(Break);
            }

            

            
        }

    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "FakeFloor")
        {
            playerCamera.isUnderground = true;
            ChangeMusic("boss");
        }

        if (coll.gameObject.CompareTag("door") == true)
        {
            transform.Translate(0, 0, 0);
            AS.PlayOneShot(Door);
            maxSpeedX = maxSpeedX - 2;
            jumpFlag = false;                                           
            doorslow = true;
        }

        if (coll.gameObject.CompareTag("GameStart") == true)
        {
            jumpFlag = false;
            AS.PlayOneShot(doorOpenSound);
            SceneManager.LoadScene("MainGame");
        }

    }

}
