using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVCat: Cat
{
    public SVCat()
    {
        hasToChange = false;

        //Find new animation
    }
    private void Awake()
    {
        hasFound = true;
    }
}
