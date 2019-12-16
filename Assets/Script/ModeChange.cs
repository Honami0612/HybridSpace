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
    public int modeNumber = 0;

    [SerializeField]
    Text lifeText;
    public int playerLife;

    string modeState;
    

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeText.text = "Life:" + playerLife.ToString();
        check.text = modeNumber.ToString();

    }

    void Update () {

        Mode();
        ChangeModeState();

	}

    void Mode()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.U) || Flute.E && Flute.F_down) modeNumber = 0; spriteRenderer.sprite = changeMode[modeNumber];
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.I) || Flute.E && Flute.G_down) modeNumber = 1; spriteRenderer.sprite = changeMode[modeNumber];
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.O) || Flute.E && Flute.A_down) modeNumber = 2; spriteRenderer.sprite = changeMode[modeNumber];

        if (Input.GetKeyDown(KeyCode.S))
        {
            modeNumber++;

            if (modeNumber < changeMode.Length)
            {
                spriteRenderer.sprite = changeMode[modeNumber];
            }
            else
            {
                modeNumber = 0;
                spriteRenderer.sprite = changeMode[modeNumber];
            }

        }
        check.text = modeNumber.ToString();
    }

    void ChangeModeState()
    {
        switch (modeNumber)
        {
            case 0:
                modeState = "Normal";
                break;
            case 1:
                modeState = "Fire";
                break;
            case 2:
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
