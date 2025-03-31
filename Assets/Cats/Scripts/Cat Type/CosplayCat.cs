using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CosplayCat : Cat
{
    [Header("Cosplay Cat Section")]
    [SerializeField] private AnimationClip[] cosplays;
    [SerializeField] private AnimatorOverrideController animatorOverrideController;
    [SerializeField] private int cosplayIndex;

    public CosplayCat()
    {
    }
    public void Start()
    {
        cosplayIndex = 5;
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }
    protected override IEnumerator ToIdle()
    {
        yield return null;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        cosplayIndex = (cosplayIndex + 1) % cosplays.Length;
        animatorOverrideController["Normal_Idle"] = cosplays[cosplayIndex];
    }
}
