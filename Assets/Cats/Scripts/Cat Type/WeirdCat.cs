using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeirdCat: Cat
{
    [Header("Weird Cat section")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    public WeirdCat()
    {
        hasToChange = false;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(ReturnToIdle());
    }
    private IEnumerator ReturnToIdle()
    {
        //TODO: Add more sprites 

        animator.SetFloat("ChangeSpeed", 0f);

        yield return new WaitForSeconds(3f);

        animator.SetFloat("ChangeSpeed", 2f);
    }
}
