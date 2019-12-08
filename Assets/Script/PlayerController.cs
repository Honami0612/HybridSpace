using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        GetInputKey();        
        ChangeState();         
    }

    private void FixedUpdate()
    {
        Move();       
    }

    void GetInputKey()
    {
            key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpForce);
                isGround = false;
            }
        }
        if (!isGround)
        {
            if (state == "FALL")
            {
                rb.AddForce(transform.up * -30f);
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

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)   isGround = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)    isGround = true;
        }
    }

   

}
