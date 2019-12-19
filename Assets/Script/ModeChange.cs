using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Move()のWindModeのフルートナンバー追加

public class ModeChange : MonoBehaviour {

    [SerializeField]
    Text check;

    [SerializeField]
    GameObject[] bodyParticle;
    private int number = 3;
    public int modeNumber = 0;

    string modeState;

    Enemy enemyScript;

    LifeEnergy lifeEnergy;
    

	void Start () {
       
        check.text = "0:Nomal"+" 1:Fire"+ " 2:Thunder"+ "3:Wind\n" + "nowMode:"+modeNumber.ToString();
        enemyScript = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        bodyParticle[modeNumber].gameObject.SetActive(true);
        lifeEnergy = GameObject.Find("Life").GetComponent<LifeEnergy>();

    }

    void Update () {
       
        Mode();
        ChangeModeState();
       

	}

    void Mode()
    {
        if (Flute.E && Flute.F_down)
        {
            modeNumber = 0;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[0].gameObject.SetActive(true);
        }
        if (Flute.E && Flute.G_down)
        {
            modeNumber = 1;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[1].gameObject.SetActive(true);
        }
        if (Flute.E && Flute.A_down)
        {
            modeNumber = 2;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[2].gameObject.SetActive(true);
        }
        if (Flute.E && Flute.B_down)
        {
            modeNumber = 3;
            foreach (GameObject body in bodyParticle) body.gameObject.SetActive(false);
            bodyParticle[3].gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            
           foreach(GameObject body in bodyParticle) body.gameObject.SetActive(false);
           
            if (modeNumber < number)
            {
                modeNumber++;
                bodyParticle[modeNumber].gameObject.SetActive(true);
            }
            else
            {
                modeNumber = 0;
                bodyParticle[modeNumber].gameObject.SetActive(true);
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

            enemyScript.state = "Attack";
            lifeEnergy.ChangeSprite();
           
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
