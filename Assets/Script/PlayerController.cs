using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;


public class PlayerController : MonoBehaviour {
    //[SerializeField]
    //Text check;

    Rigidbody2D rb;
    
    [SerializeField]
    float jumpForce = 390.0f;       
    float jumpThreshold = 2.0f;
    [SerializeField]
    float runSpeed = 0.5f;       
    bool isGround = true;        
    int key = 0;                 

    string state;                
    float stateEffect = 1;

    private float jumpCount=0;

    [SerializeField]
    GameObject ball;
    //[SerializeField]
    //GameObject mator;

    Animator characterAnimation;
    ModeChange modeChange;

    [SerializeField]
    Image howto;

    void Start()
    {
        howto.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<Animator>();
        modeChange = GetComponent<ModeChange>();
    }

    void Update()
    {

        GetInputKey();
        Move();

        ChangeState();
        HitEnemy();
        ChangeAnimation();
        if (Input.GetKey(KeyCode.Z))
        {
            howto.enabled = true;
        }else if (Input.GetKey(KeyCode.X))
        {
            howto.enabled = false;
        }

    }

    private void FixedUpdate()
    {
          
    }

    void GetInputKey()
    {
            key = 0;
        if (Input.GetKey(KeyCode.D) || Flute.C && Flute.G)
        { 
            key = 1;
        }
            
        if (Input.GetKey(KeyCode.A) || Flute.C && Flute.F)
            key = -1;
    }

    void ChangeState()
    {
        if (Mathf.Abs(rb.velocity.y) > jumpThreshold)
        {
            isGround = false;
        }

        if (isGround)
        {
            if (key != 0)
            {
                    state = "Run";
            }
            else
            {
                state = "Idle";
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                state = "Jump";
            }
            else if (rb.velocity.y < 0)
            {
                state = "Fall";
            }
        }

    }

  

    void Move()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Flute.C && Flute.A_down)
            {
                //jump
                state = "Jump";//"Jump";
                rb.AddForce(transform.up * jumpForce);
                isGround = false;
            }
            if (Input.GetKeyDown(KeyCode.Q) || Flute.D && Flute.A_down)
            {
                //bigjump
                state = "Jump";// "Jump";
                rb.AddForce(transform.up * 700f) ;
                isGround = false;
            }
        }
        if (!isGround)
        {
            //if (Input.GetKeyDown(KeyCode.Space) || Flute.C && Flute.A_down)
            //{
            //    if (jumpCount <1)
            //    {
            //        rb.AddForce(transform.up * jumpForce);
            //        jumpCount++;
            //    }
            //}
            if (state == "Fall")
            {
                rb.AddForce(transform.up * -100f);
            }
        }
        
        rb.velocity = new Vector2(key * runSpeed, rb.velocity.y);
        

    }

    void ChangeAnimation()
    {
        switch (state)
        {
            case "Idle":
                characterAnimation.SetInteger("Idle", modeChange.nowNumber);
                characterAnimation.SetBool("Idlee", true);
                characterAnimation.SetBool("Run", false);
                characterAnimation.SetBool("Jump", false);
                break;

            case "Run":
                characterAnimation.SetBool("Idlee", false);
                characterAnimation.SetBool("Run", true);
                characterAnimation.SetBool("Jump", false);
                transform.localScale = new Vector3(key * 0.3f, 0.3f, 0.3f);
                break;

            case "Jump":
                characterAnimation.SetBool("Jump", true);
                characterAnimation.SetBool("Idlee", false);
                characterAnimation.SetBool("Run", false);
                
                break;

        }
    }

   void HitEnemy()
    {
        if (Input.GetKeyDown(KeyCode.C)|| Flute.C && Flute.B_down || Flute.D && Flute.B_down)
        {
           
            Instantiate(ball, new Vector3(this.gameObject.transform.position.x + 2.5f, this.gameObject.transform.position.y, 0), Quaternion.identity);
            //Instantiate(mator, new Vector3(this.gameObject.transform.position.x + 2.5f, this.gameObject.transform.position.y, 0), Quaternion.identity);
        }
       
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)   isGround = true;
            jumpCount = 0;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)    isGround = true;
            jumpCount = 0;
        }
    }

   
}
