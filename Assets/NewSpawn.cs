using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> cats = new List<GameObject>();    
    [SerializeField] private List<GameObject> chosenCats = new List<GameObject>();    
    [SerializeField] private float cooldown = 0;
    [SerializeField] private float time = System.DateTime.Now.Hour;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ChooseCat()
    {
        for (int i = 0; i < cats.Count; i++)
        {
            if (time > cats[i].GetComponent<ScriptableCat>().TimeIn && time < cats[i].GetComponent<ScriptableCat>().TimeOut) chosenCats.Add(cats[i]);
        }
    }
    private Transform ChooseSpawnPoint()
    {
        //To do: Add a method to randomly choose spawn point
        return null;
    }
    private void SpanwCat()
    {
        float time = 0;
        if (time < cooldown) time += Time.deltaTime;
        else
        {
            time = 0;
            cooldown = Random.Range(30, 301);
            if (chosenCats[0] == null) return;
            else Instantiate(chosenCats[0]);
        }
    }
}
