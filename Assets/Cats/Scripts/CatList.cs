using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CatList : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cats;
    public GameObject GetCat()
    { 
        //int temp = Random.Range(1, Cats.Count + 1);

        //foreach (var cat in Cats)
        //{
        //    if (temp == cat.GetComponent<Cat>().spawnRate) return cat;
        //}

        //return null;

        //int hour = System.DateTime.Now.Hour;    

        //foreach (var cat in Cats)
        //{
        //    if (hour >= cat.GetComponent<Cat>().timeStart && hour <= cat.GetComponent<Cat>().timeEnd) return cat;
        //}

        return Cats[0];
    }
    public List<GameObject> GetCatList()
    {
        List<GameObject> selectedCatList = new List<GameObject>();
        int hour = System.DateTime.Now.Hour;

        foreach (var cat in Cats)
        {
            //if (hour >= cat.GetComponent<Cat>().timeStart && hour <= cat.GetComponent<Cat>().timeEnd) selectedCatList.Add(cat); 
            if (hour < cat.GetComponent<Cat>().spawnRate) selectedCatList.Add(cat);
        }

        return selectedCatList; 
    }
    public void SpawnCat(GameObject Bedroom)
    {
        GameObject cat = GetCat();  
        //int hour = System.DateTime.Now.Hour;    

        //if (hour >= cat.GetComponent<Cat>().timeStart && hour <= cat.GetComponent<Cat>().timeEnd) Instantiate(GetCat(), transform.position, transform.rotation);
        
        //GameObject cat = Instantiate(GetCat(), transform.position, transform.rotation);
        cat.transform.SetParent(Bedroom.transform);
    }
}
