using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private CatManager catManager;
    [SerializeField] private RawImage rawImage;

    private void Start()
    {
        catManager = GameObject.Find("Cat Manager").GetComponent<CatManager>(); 
    }
    public void SaveCat()
    {
        SaveSystem.SaveCat(catManager);
    }
    public void DeleteCat()
    {
        SaveSystem.DeleteCat();
    }
    public void LoadCat()
    {
        CatData catData = SaveSystem.LoadCat();

        foreach (var name in catManager.catNames)
        {
            if (rawImage.GetComponent<Image>().needCatImage == name)
            {
                rawImage.color = Color.white;
                break;
            }
        }
    }
}
