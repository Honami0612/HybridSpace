using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool breakDown=false;
    public bool nobreak=false;

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (breakDown)
            {
                Destroy(this.gameObject);
            }else if (nobreak)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
        } 
    }
}
