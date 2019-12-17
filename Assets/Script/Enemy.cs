using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    Text enemyMode;

    public int enemyAttribute;
    private int playerMode;
    ModeChange modeChange;

    Animator enemyAnimator;
    public string state;

    private GameObject field;
    private Rigidbody2D rb;
    private Vector3 pos;

    // Use this for initialization
    void Start () {
        field = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        pos = field.transform.position;
        modeChange = GameObject.FindWithTag("Player").GetComponent<ModeChange>();
        enemyAnimator = GetComponent<Animator>();
        state = "Idle";
    }
	
	// Update is called once per frame
	void Update () {
		playerMode=modeChange.nowNumber;
        ChangeAnimation();
        enemyMode.text = state.ToString() ;
        Move();
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            if (enemyAttribute == playerMode)
            {
                Destroy(this.gameObject);
            }
           
        }
    }

    void Move()
    {
        if (state != "Attack")
        {
            state = "Walk";
            rb.MovePosition(new Vector3(pos.x + Mathf.PingPong(Time.deltaTime, 3), pos.y, pos.z));
        }
        
    }

    void ChangeAnimation()
    {
        switch (state)
        {
            case "Idle":
                enemyAnimator.SetBool("Idle", true);
                enemyAnimator.SetBool("Walk", false);
                enemyAnimator.SetBool("Attack", false);
                break;
            case "Walk":
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Walk", true);
                enemyAnimator.SetBool("Attack", false);
                break;
            case "Attack":
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Walk", false);
                enemyAnimator.SetBool("Attack", true);
                break;


        }
    }
}
