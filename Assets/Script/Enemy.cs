using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    
    public int enemyAttribute;
    private int playerMode;
    ModeChange modeChange;

	// Use this for initialization
	void Start () {
        modeChange = GameObject.FindWithTag("Player").GetComponent<ModeChange>();
    }
	
	// Update is called once per frame
	void Update () {
		playerMode=modeChange.nowNumber;
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
}
