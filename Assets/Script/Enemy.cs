using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //[SerializeField]
    //Text enemyMode;

    public int enemyAttribute;
    private int playerMode;
    ModeChange modeChange;

    Animator enemyAnimator;
    public string state;

    private GameObject field;
    private Rigidbody2D rb;
    private Vector3 pos;

    public AudioClip die;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        field = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        pos = field.transform.position;
        modeChange = GameObject.FindWithTag("Player").GetComponent<ModeChange>();
        enemyAnimator = this.gameObject.GetComponent<Animator>();
        state = "Idle";
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		playerMode=modeChange.nowNumber;
        ChangeAnimation();
        Move();
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            if (enemyAttribute == playerMode)
            {
                audioSource.clip = die;
                audioSource.Play();
                StartCoroutine(SoundWait());
            }
           
        }
    }

    void Move()
    {
        if (state != "Attack")
        {
            state = "Walk";
            
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
                StartCoroutine(Wait());
                break;


        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        state = "Idle";
    }
    IEnumerator SoundWait()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

}
