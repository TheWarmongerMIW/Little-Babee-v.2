using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetName : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{spriteRenderer.name}");
    }
}
