using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    [SerializeField] public List<string> catNames = new List<string>();

    public void AddCatToList(GameObject cat)
    {
        if (!catNames.Contains(cat.name)) catNames.Add(cat.name);
    }
}
