using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCat : Cat
{
    [Header("Orange Cat section")]
    [SerializeField] private BoxCollider2D boxCollider;
    public OrangeCat()
    {

    }
    public void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (isChanging) boxCollider.enabled = false;
        else boxCollider.enabled = true;
    }
}
