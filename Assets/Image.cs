using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Image : MonoBehaviour
{
    [SerializeField] public string catName;
    [SerializeField] private CatData catData;
    [SerializeField] private RawImage rawImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadImage()
    {
        foreach (var name in catData.catNames)
        {
            if (catName == name)
            {
                rawImage.color = Color.white;
                break;
            }
        }
    }
}
