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

	public float rushSpeed;
    public float rushDuration;
	private float rushTimer;
    private int direction = 1;
	public float highJumpForce;

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
		if (Input.GetKey(KeyCode.D) || Flute.C && Flute.G) { key = 1; ChangeDirection(1); }
		if (Input.GetKey(KeyCode.A) || Flute.C && Flute.F) { key = -1; ChangeDirection(-1); }
		if (Flute.F_up && key != 1 || Flute.G_up && key != -1) key = 0;

		if (Flute.D && Flute.F_down || Flute.D && Flute.G_down)
		{
			ChangeDirection(-1);
			rushTimer = rushDuration;
			rb.velocity = new Vector2(direction * rushSpeed, rb.velocity.y);
		}

		if (Flute.D && Flute.G_down)
		{
			ChangeDirection(1);
			rushTimer = rushDuration;
			rb.velocity = new Vector2(direction * rushSpeed, rb.velocity.y);
		}

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
            if (Input.GetKeyDown(KeyCode.Space) || Flute.C && Flute.A_down)
            {
				//state = "Idle";
				rb.velocity = new Vector2(rb.velocity.x, 0);
				rb.AddForce(transform.up * jumpForce);
                jumpCount++;
            }

            //High jump
			else if (Flute.D && Flute.A_down)
			{
				rb.velocity = new Vector2(rb.velocity.x, 0);
				rb.AddForce(transform.up * highJumpForce);
				jumpCount++;
			}
		}
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Flute.C && Flute.A_down)
            {
                if (jumpCount <1)
                {
					rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(transform.up * jumpForce);
                    jumpCount++;
                }
            }
            //if (state == "Fall")
            //{
            //    rb.AddForce(transform.up * -100f);
            //}
        }

        if (rushTimer > 0)
		{
            rushTimer -= Time.deltaTime;
		}
		else
		{
			rb.velocity = new Vector2(key * runSpeed, rb.velocity.y);
		}

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

                
                break;
        }
    }

    void ChangeDirection(int dir)
	{
		direction = dir;
		transform.localScale = new Vector3(direction * 0.3f, 0.3f, 0.3f);
	}

   void HitEnemy()
    {
        if (Input.GetKeyDown(KeyCode.C)|| Flute.C && Flute.B_down)
        {
            //if (transform.localScale.x = 0.3f)
            //{

            //}
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

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			isGround = false;
		}
	}


}
