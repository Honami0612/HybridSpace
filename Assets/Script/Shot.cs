using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour {

    

    private GameObject mator;
    bool changeRote;

    float rota;
    float angle;
    float rad;
    float addForce_x;
    float addForce_y;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        mator = GameObject.Find("arrow(Clone)");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.P) || Flute.C && Flute.B)
        {
            Mator();
        }
        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.P) || Flute.B_up)
        {
            MoveShot();
        }

    }

    void Mator()
    {
        
        if (0.1f >= mator.transform.eulerAngles.z)
        {
            changeRote = true;
        }
        if (90 <= mator.transform.eulerAngles.z)
        {
            changeRote = false;
        }

        if (changeRote)
        {
            rota = 1;
        }
        else
        {
            rota = -1;
        }

        mator.transform.Rotate(0, 0, rota);
        
        angle = mator.transform.eulerAngles.z;
        rad = angle * Mathf.Deg2Rad;
        addForce_x = Mathf.Cos(rad) * 1500f;
        addForce_y = Mathf.Sin(rad) * 1500f;

    }

    void MoveShot()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        this.rb.AddForce(new Vector2(addForce_x, addForce_y));
        Destroy(mator);

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
