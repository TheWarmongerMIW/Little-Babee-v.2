using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cat: MonoBehaviour, IPointerDownHandler
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
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
