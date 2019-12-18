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

    Enemy enemyScript;
    

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeText.text = "Life:" + playerLife.ToString();
        check.text = "0:Nomal"+" 1:Fire"+ " 2:Thunder\n" + "nowMode:"+modeNumber.ToString();
        enemyScript = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();

    }

    void Update () {

        Mode();
        ChangeModeState();

	}

    void Mode()
    {
        if (Flute.E && Flute.F_down) modeNumber = 0; spriteRenderer.sprite = changeMode[modeNumber];
        if (Flute.E && Flute.G_down) modeNumber = 1; spriteRenderer.sprite = changeMode[modeNumber];
        if (Flute.E && Flute.A_down) modeNumber = 2; spriteRenderer.sprite = changeMode[modeNumber];

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
        check.text = "0:Nomal" + " 1:Fire" + " 2:Thunder\n" + "nowMode:" + modeNumber.ToString();
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
            enemyScript.state = "Attack";
            playerLife -= 20;
            lifeText.text = "Life:"+playerLife.ToString();
            StartCoroutine(EnemyMode());
        }
    }

    public int nowNumber
    {
        get { return modeNumber; }
        set { modeNumber = value; }
    }

    IEnumerator EnemyMode()
    {
        yield return new WaitForSeconds(0.5f);
        enemyScript.state = "Idle";
    }


}
