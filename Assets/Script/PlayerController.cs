using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class PlayerController : MonoBehaviour {

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //checkText.text = jumpCount.ToString() + " state" + state;

        GetInputKey();        
        ChangeState();
        HitEnemy();

    }

    private void FixedUpdate()
    {
        Move();       
    }

    void GetInputKey()
    {
            key = 0;
        if (Input.GetKey(KeyCode.D) || Flute.C || Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.I))
            key = 1;
        if (Input.GetKey(KeyCode.A) || Flute.D || Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.U))
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
                state = "RUN";
            }
            else
            {
                state = "IDLE";
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                state = "JUMP";
            }
            else if (rb.velocity.y < 0)
            {
                state = "FALL";
            }
        }

    }

  

    void Move()
    {
        if (isGround)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.Space) || Flute.breath || Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.O))
            {

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
            if (state == "FALL")
            {
                rb.AddForce(transform.up * -100f);
            }
        }
        
        float speedX = Mathf.Abs(rb.velocity.x);
        if (speedX < runThreshold)
        {
            rb.AddForce(transform.right * key * runForce * stateEffect); 
        }
        else
        {
            transform.position += new Vector3(runSpeed * Time.deltaTime * key * stateEffect, 0, 0);
        }

    }

   void HitEnemy()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.P))
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
