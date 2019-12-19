using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    public float moveX = 0.5f;
    public float moveY = 0.5f;
    private Renderer render;
    
    private void Start()
    {
        render = GetComponent<Renderer>();
        Debug.Log(render);
    }

    // Update is called once per frame
    private void Update()
    {
        float offsetX = Time.deltaTime * moveX;
        float offSetY = Time.deltaTime * moveY;

        render.material.mainTextureOffset = new Vector2(offsetX, offSetY);
    }
}
