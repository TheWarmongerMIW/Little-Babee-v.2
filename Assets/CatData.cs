using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatData
{
    public bool hasFound;
    public float[] position;

    public CatData(Cat cat)
    {
        this.hasFound = cat.hasFound;

        this.position[0] = cat.transform.position.x;
        this.position[1] = cat.transform.position.y;
        this.position[2] = cat.transform.position.z;
    }
}
