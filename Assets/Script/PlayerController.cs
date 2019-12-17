using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class PlayerController : MonoBehaviour {
    //[SerializeField]
    //Text checkText;

    Rigidbody2D rb;
    
    [SerializeField]
    float jumpForce = 390.0f;       
    float jumpThreshold = 2.0f;    
    [SerializeField]
    float runForce = 30.0f;      
    [SerializeField]
    float runSpeed = 0.5f;       
    float runThreshold = 2.0f;   
    bool isGround = true;        
    int key = 0;                 

    string state;                
    float stateEffect = 1;

    private float jumpCount=0;

    [SerializeField]
    GameObject ball;
    [SerializeField]
    GameObject mator;

    Animator characterAnimation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        

        GetInputKey();        
        ChangeState();
        HitEnemy();
        ChangeAnimation();

    }

    private void FixedUpdate()
    {
        Move();       
    }

    void GetInputKey()
    {
            key = 0;
        if (Input.GetKey(KeyCode.D) || Flute.B && Flute.E)
        {
            //print("heyYo");
            key = 1;

        }
            
        if (Input.GetKey(KeyCode.A) || Flute.B && Flute.F)
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
            //jump
            if (Input.GetKeyDown(KeyCode.Space) || Flute.B && Flute.D_down)
            {
                state = "Idle";
                rb.AddForce(transform.up * jumpForce);
                jumpCount++;
                isGround = false;
              }
        }
        if (!isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCount <1)
                {
                    rb.AddForce(transform.up * jumpForce);
                    jumpCount++;
                }
            }
            if (state == "Fall")
            {
                rb.AddForce(transform.up * -100f);
            }
        }
        
        rb.velocity = new Vector2(key * runSpeed, rb.velocity.y);
        //Debug.Log("Walking like shit");
        //Debug.Log(key + "<key runspeed>" + runSpeed);
        //Debug.Log($"key = {key}　Runspeed = {runSpeed}");

    }

    void ChangeAnimation()
    {
        switch (state)
        {
            case "Idle":
                characterAnimation.SetBool("Idle", true);
                characterAnimation.SetBool("Run", false);
               
                break;
            case "Run":
                characterAnimation.SetBool("Idle", false);
                characterAnimation.SetBool("Run", true);
                transform.localScale = new Vector3(key*0.3f, 0.3f, 0.3f);

                
                break;
        }
    }

   void HitEnemy()
    {
        if (Input.GetKeyDown(KeyCode.C)|| Flute.B && Flute.C_down)
        {
            Instantiate(ball, new Vector3(this.gameObject.transform.position.x + 2.5f, this.gameObject.transform.position.y, 0), Quaternion.identity);
            Instantiate(mator, new Vector3(this.gameObject.transform.position.x + 2.5f, this.gameObject.transform.position.y, 0), Quaternion.identity);
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
