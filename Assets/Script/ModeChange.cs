using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] changeMode;
    int modeNumber = 0;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        Mode();
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
    }
}
