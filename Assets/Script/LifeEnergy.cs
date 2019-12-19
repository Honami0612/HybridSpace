using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeEnergy : MonoBehaviour
{
    private Image image;
    public Sprite[] lifeEnergy;
    private int lifeSpritenumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSpritenumber > 9)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

   public void ChangeSprite()
    {
        lifeSpritenumber++;
        image.sprite = lifeEnergy[lifeSpritenumber];
        
        Debug.Log(lifeSpritenumber);
    }
}
