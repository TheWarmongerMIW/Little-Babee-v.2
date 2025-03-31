using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCat : Cat
{
    [Header("Pink Cat section")]
    [SerializeField] private BoxCollider2D boxCollider;
    public PinkCat()
    {
        
    }
    private void FixedUpdate()
    {
        if (isChanging) boxCollider.enabled = false;
        else boxCollider.enabled = true;
    }
}
