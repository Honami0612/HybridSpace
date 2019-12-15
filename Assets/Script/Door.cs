using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    //[SerializeField]
    //Text check;

    public int doorNumber;
    ModeChange modeChange;
    private int modeNumber;

    FadeController fadeController;

	void Start () {
        modeChange = GameObject.FindWithTag("Player").GetComponent<ModeChange>();
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
        Debug.Log(SceneManager.GetActiveScene().name);
	}
	
	void Update () {
        modeNumber = modeChange.nowNumber;
        //Debug.Log(modeNumber);
        //check.text = modeNumber.ToString()+""+doorNumber.ToString();
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (doorNumber == modeNumber)
            {
                //check.text = "true";
                Debug.Log("doorClear");
                fadeController.isFadeOut = true;
                StartCoroutine(ChangeScene());
            }
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().name == "Tutorial1")
        {
            SceneManager.LoadScene("Tutorial2");
        }else if (SceneManager.GetActiveScene().name == "Tutorial2")
        {
            SceneManager.LoadScene("Tutorial1");
            Debug.Log("GameStart");
            //GameStart
        }
        
    }
}
