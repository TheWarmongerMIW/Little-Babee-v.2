using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat: MonoBehaviour
{
    [SerializeField] public int spawnRate;
    [SerializeField] public int timeStart;
    [SerializeField] public int timeEnd;
    [SerializeField] private string currentState;
    [SerializeField] private Animator animator;


    const string IDLE = "Idle";
    const string NOTHING = "Nothing";

    private void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimState(IDLE);
    }
    public void ChangeAnimState(string newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        animator.Play(currentState);
    }
}
