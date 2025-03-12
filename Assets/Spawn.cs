using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private float Delay;
    [SerializeField] private CatList catList;
    [SerializeField] private bool isDone = false;   
    [SerializeField] private bool isSelected = false;   
    void Start()
    {
        catList = this.GetComponent<CatList>();
    }

    void Update()
    {
        catList.GetCat();

        if (!isSelected)
        {
            Delay = Random.Range(20, 61);
            isSelected = true;
        }

        if (Timer < Delay && !isDone)
        {
            Timer += Time.deltaTime;
        }
        else if (!isDone)
        {
            catList.SpawnCat();
            Timer = 0;
            isDone = true;
            isSelected = false;
        }
    }
}
