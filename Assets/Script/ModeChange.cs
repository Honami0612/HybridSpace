using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Move()のWindModeのフルートナンバー追加

public class ModeChange : MonoBehaviour {

    [SerializeField]
    Text check;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject[] bodyParticle;
    private int number = 3;
    public int modeNumber = 0;

    [SerializeField]
    Text lifeText;
    public int playerLife;

    string modeState;

    Enemy enemyScript;

    SpriteRenderer nowLifeSprite;
    [SerializeField]
    Sprite[] lifeSprite;
    int lifeSpritenumber=0;
    

	void Start () {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeText.text = "Life:" + playerLife.ToString();
        check.text = "0:Nomal"+" 1:Fire"+ " 2:Thunder"+ "3:Wind\n" + "nowMode:"+modeNumber.ToString();
        enemyScript = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        bodyParticle[modeNumber].gameObject.SetActive(true);
        nowLifeSprite = GameObject.Find("nowLife").GetComponent<SpriteRenderer>();


    }

    void Update () {
       
        Mode();
        ChangeModeState();
        if (lifeSpritenumber >= 10)
        {
            SceneManager.LoadScene("GameOver");
            //GameOver
        }

	}

    void Mode()
    {
        if (Flute.G && Flute.F_down)
        {
            modeNumber = 0;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[0].gameObject.SetActive(true);
            //spriteRenderer.sprite = changeMode[modeNumber];
        }
        if (Flute.G && Flute.E_down)
        {
            modeNumber = 1;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[1].gameObject.SetActive(true);
            //spriteRenderer.sprite = changeMode[modeNumber];
        }
        if (Flute.G && Flute.D_down)
        {
            modeNumber = 2;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[2].gameObject.SetActive(true);
            //spriteRenderer.sprite = changeMode[modeNumber];
        }
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            
           foreach(GameObject body in bodyParticle) body.gameObject.SetActive(false);
           
            if (modeNumber < number)
            {
                modeNumber++;
                bodyParticle[modeNumber].gameObject.SetActive(true);
                //spriteRenderer.sprite = changeMode[modeNumber];
            }
            else
            {
                modeNumber = 0;
                bodyParticle[modeNumber].gameObject.SetActive(true);
                //spriteRenderer.sprite = changeMode[modeNumber];
            }

        }
        check.text = "0:Nomal" + " 1:Fire" + " 2:Thunder"+ " 3:Wind\n" + "nowMode:" + modeNumber.ToString();
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
            nowLifeSprite.sprite = lifeSprite[lifeSpritenumber];
            lifeSpritenumber++;
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
