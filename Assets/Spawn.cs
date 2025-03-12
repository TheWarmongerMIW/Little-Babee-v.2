using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Bedroom;
    [SerializeField] private float Timer;
    [SerializeField] private float Delay;
    [SerializeField] private CatList catList;
    void Start()
    {
        catList = this.GetComponent<CatList>();
    }

    void Update()
    {
        catList.GetCat();

        if (Timer < Delay )
        {
            Timer += Time.deltaTime;
        }
        else
        {
            catList.SpawnCat(Bedroom);
            Timer = 0;
        }
    }
}
