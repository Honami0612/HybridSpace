using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChange : MonoBehaviour {

    [SerializeField]
    Text check;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] changeMode;
    public int modeNumber = 1;

    [SerializeField]
    Text lifeText;
    public int playerLife;

    string modeState;
    

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeText.text = "Life:" + playerLife.ToString();
        check.text = modeNumber.ToString();

    }

    // Update is called once per frame
    void Update () {

        Mode();
        ChangeModeState();

	}

    void Mode()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (modeNumber < changeMode.Length)
            {
                spriteRenderer.sprite = changeMode[modeNumber];
                modeNumber++;
            }
            else
            {
                modeNumber = 0;
                spriteRenderer.sprite = changeMode[modeNumber];
                modeNumber++;
            }
          
        }
        check.text = modeNumber.ToString();
    }

    void ChangeModeState()
    {
        switch (modeNumber)
        {
            case 1:
                modeState = "Normal";
                break;
            case 2:
                modeState = "Fire";
                break;
            case 3:
                modeState = "Thunder";
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerLife -= 20;
            lifeText.text = "Life:"+playerLife.ToString();
        }
    }

    public int nowNumber
    {
        get { return modeNumber; }
        set { modeNumber = value; }
    }

    


}
