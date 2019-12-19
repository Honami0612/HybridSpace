using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour {

    PlayerController playerController;
    Transform playerObject;

    //private GameObject mator;
    //bool changeRote;

    //float rota;
    //float angle;
    //float rad;
    //float addForce_x;
    //float addForce_y;

    Rigidbody2D rb;

    int key;

    ModeChange modeChange;
    [SerializeField]
    GameObject[] particle;
    int modeNumber;

    AudioSource audioSource;
    public AudioClip shoot;

   

	// Use this for initialization
	void Start () {
       
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerObject = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.rb = GetComponent<Rigidbody2D>();
        //mator = GameObject.Find("arrow(Clone)");
        modeChange = GameObject.FindWithTag("Player").GetComponent<ModeChange>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetKey(KeyCode.C)|| Flute.C && Flute.B)
        //{
        //    Mator();
        //}
        if (Input.GetKeyUp(KeyCode.C)|| Flute.B_up)
        {
            MoveShot();
        }

    }

    void Mator()
    {

        //if (0.1f >= mator.transform.eulerAngles.z)
        //{
        //    changeRote = true;
        //}
        //if (90 <= mator.transform.eulerAngles.z)
        //{
        //    changeRote = false;
        //}

        //if (changeRote)
        //{
        //    rota = 1;
        //}
        //else
        //{
        //    rota = -1;
        //}

        //mator.transform.Rotate(0, 0, rota);

        //angle = mator.transform.eulerAngles.z;
        //rad = angle * Mathf.Deg2Rad;
        //addForce_x = Mathf.Cos(rad) * 1000f;
        //addForce_y = Mathf.Sin(rad) * 1000f;
        

    }

    void MoveShot()
    {
        //audioSource.clip = shoot;
        //audioSource.Play();
        modeNumber = modeChange.nowNumber;
        rb.bodyType = RigidbodyType2D.Dynamic;
        GameObject obj = Instantiate(particle[modeNumber], new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 1f), Quaternion.identity);
        obj.transform.parent = this.gameObject.transform;
        this.rb.velocity = new Vector2(100f, 0);

        //this.rb.AddForce(new Vector2(addForce_x, addForce_y));
        //Destroy(mator);

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
