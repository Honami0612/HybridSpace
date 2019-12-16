using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playertest : MonoBehaviour
{
    Animator playerAnimator;
    string state;
    [SerializeField]
    Text check;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StateChange();
        ChangeAnimation();
        check.text = state;
    }

    void StateChange()
    {
        if (Input.GetKey(KeyCode.L))
        {
            state = "Run";
        }
        else
        {
            state = "Idle";
        }
        
    }
    void ChangeAnimation()
    {
        switch (state)
        {
            case "Idle":
                playerAnimator.SetBool("Idle", true);
                playerAnimator.SetBool("Run", false);
                break;
            case "Run":
                playerAnimator.SetBool("Idle", false);
                playerAnimator.SetBool("Run", true);
                break;
        }
    }
}
