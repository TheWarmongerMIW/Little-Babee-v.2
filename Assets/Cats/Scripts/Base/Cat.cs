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
    [SerializeField] protected Animator animator;
    [SerializeField] protected string currentState;
    [SerializeField] protected bool isChanging = false;
    [SerializeField] protected bool changeToIdle = false;

    [Header("Cat stay time")]
    [SerializeField] protected float stayTime;

    [Header("Scriptable Cat")]
    public ScriptableCat cat;
    public bool hasFound = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        stayTime = UnityEngine.Random.Range(60, 181);
    }
    private void Update()
    {
        Leave();
        if (!isChanging) StartCoroutine(ToIdle());

        if (Input.GetKey(KeyCode.Backspace)) stayTime = 0;
    }

    private void Leave()
    {
        stayTime -= Time.deltaTime;
        if (stayTime <= 0) Destroy(gameObject);
    }

    #region Click 
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) ToOnClick();
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnClick"))
        {
            if (animator.HasState(0, Animator.StringToHash("OnEnter")))
            {
                if (!changeToIdle) ToOnEnter();
            }
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
    protected void ChangeAnim(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
    protected virtual IEnumerator ToIdle()
    {
        isChanging = true;

        if (animator.HasState(0, Animator.StringToHash("OnEnter")))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnEnter"))
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                ChangeAnim("Idle");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("OnClick") && changeToIdle)
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
                ToOnEnter();
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
    protected void ToOnClick()
    {
        ChangeAnim("OnClick");
    }
    protected void ToOnEnter()
    {
        ChangeAnim("OnEnter");
    }
    #endregion
}
