using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.01f;

    Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float y =  material.mainTextureOffset.y + scrollSpeed *Time.deltaTime;

        Vector2 newOffSet = new Vector2(0, y);

        material.mainTextureOffset = newOffSet;
    }
}
