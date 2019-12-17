using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemytest : MonoBehaviour
{
    Animator enemyAnimator;
    string state;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
        ChangeAnimation();
    }

    void ChangeState()
    {
        if (Input.GetKey(KeyCode.D))
        {
            state = "Walk";
        }
        if (Input.GetKey(KeyCode.A))
        {
            state = "Attack";
        }
        if (Input.GetKey(KeyCode.S))
        {
            state = "Idle";
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
