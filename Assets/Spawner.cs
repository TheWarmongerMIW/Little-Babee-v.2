using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Bedroom;
    [SerializeField] private CatList catList;
    [SerializeField] private List<GameObject> selectedCats = new List<GameObject>(); 
    [SerializeField] private List<Transform> chosenPos = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        catList = GetComponent<CatList>();  

        foreach (var cat in catList.GetCatList())
        {
            selectedCats.Add(cat);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (chosenPos.Count == 0) return;

        GameObject cat = catList.GetCat();
        int take = Random.Range(1, chosenPos.Count);

        for (int i = 0; i < take; i++)
        {
            int randomPos = Random.Range(0, chosenPos.Count);
            int randomCat = Random.Range(0, selectedCats.Count);
            GameObject cat1 = Instantiate(selectedCats[randomCat], chosenPos[randomPos].position, chosenPos[randomPos].rotation);
            cat1.transform.SetParent(Bedroom.transform);
            
            chosenPos.RemoveAt(randomPos);
        }
    }
}
