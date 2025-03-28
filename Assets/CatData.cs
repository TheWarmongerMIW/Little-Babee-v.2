using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatData
{
    public List<string> catNames = new List<string>();   

    public CatData(CatManager catManager)
    {
        foreach (var cat in catManager.catNames)
        {
            this.catNames.Add(cat);   
        }
    }
}
