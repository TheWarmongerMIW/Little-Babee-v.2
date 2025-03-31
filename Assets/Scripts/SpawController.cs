using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnController : MonoBehaviour
{
    [Header("Spanw point list")]
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject chosenSpawn;

    [Header("Cat list")]
    [SerializeField] private List<GameObject> cats = new List<GameObject>();

    [Header("Chosen cats list")]
    [SerializeField] private List<GameObject> chosenCats = new List<GameObject>();

    [Header("Other")]
    [SerializeField] private GameObject Bedroom;
    [SerializeField] private CatManager catManager;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private float cooldown = 0;
    [SerializeField] private float randomNum = 0;

    private bool isDone = false;

    void Start()
    {
        cooldown = Random.Range(30, 241);
        randomNum = Random.Range(1, 101);
        catManager = GameObject.Find("Cat Manager").GetComponent<CatManager>();    
        saveManager = GameObject.Find("Save Manager").GetComponent<SaveManager>();
    }
    void Update()
    {
        ChooseCat();
        ChooseSpawnPoint();
        SpawnCat();

        if (Input.GetKey(KeyCode.Space)) cooldown = 0; //Hack
    }
    private void ChooseCat()
    {
        if (!isDone)
        {
            randomNum = Random.Range(1, 101);
            foreach (var cat in cats)
            {
                if (randomNum <= cat.GetComponent<Cat>().cat.spawnRate) chosenCats.Add(cat);
            }
        }

        if (chosenCats.Count != 0) isDone = true;
        else if (chosenCats.Count == 0) isDone = false;
    }
    private void ChooseSpawnPoint()
    {
        if (chosenSpawn == null)
        {
            int num = Random.Range(0, spawnPoints.Count);

            chosenSpawn = spawnPoints[num];
        }
    }
    private void SpawnCat()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = Random.Range(30, 241);

            if (chosenCats.Count == 0) return;
            else
            { 
                int randomCat = Random.Range(0, chosenCats.Count);

                if (chosenSpawn.GetComponent<Spawn>().cat == null)
                {
                    
                    GameObject chosenCat = Instantiate(chosenCats[randomCat], chosenSpawn.transform.position, chosenSpawn.transform.rotation);
                    chosenCats.RemoveAt(randomCat);

                    catManager.AddCatToList(chosenCat);
                    saveManager.SaveCat();
                    saveManager.LoadCat();

                    chosenCat.transform.SetParent(Bedroom.transform);
                   
                    chosenSpawn.GetComponent<Spawn>().cat = chosenCat;
                    chosenSpawn = null;
                }
                else
                {
                    chosenSpawn = null;
                }
            }
        }
    }
}
