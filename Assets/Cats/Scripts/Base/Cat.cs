using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class Cat : MonoBehaviour, IPointerDownHandler
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string currentState;
    [SerializeField] private bool isChanging = false;
    [SerializeField] protected bool hasToChange = false;

    [Header("Cat stay time")]
    [SerializeField] private float stayTime;

    [Header("Scriptable Cat")]
    public ScriptableCat cat;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        stayTime = UnityEngine.Random.Range(60, 181);
    }
    private void Update()
    {
        Leave();
        if (!isChanging) StartCoroutine(ToIdle());
    }

    private void Leave()
    {
        stayTime -= Time.deltaTime;
        if (stayTime <= 0) Destroy(gameObject);
    }

    #region Click 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) ToOnClick();
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnClick"))
        {
            if (animator.HasState(0, Animator.StringToHash("OnEnter"))) ToOnEnter();
            else ChangeAnim("Idle");
        }
    }
    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
    #endregion

    #region Change Animation
    private void ChangeAnim(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
    private IEnumerator ToIdle()
    {
        isChanging = true;

        if (animator.HasState(0, Animator.StringToHash("OnEnter")))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnEnter"))
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                ChangeAnim("Idle");
            }
            else if (hasToChange)
            {
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("OnClick"))
        {
                    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                    ToOnEnter();
                }
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnClick"))
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                ChangeAnim("Idle");
            }
        }

        isChanging = false;
    }
    private void ToOnClick()
    {
        ChangeAnim("OnClick");
    }
    private void ToOnEnter()
    {
        ChangeAnim("OnEnter");
    }
    #endregion
}
