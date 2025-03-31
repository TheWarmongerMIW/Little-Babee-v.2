using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeirdCat : Cat
{
    [Header("Weird Cat section")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private float delay;

    public WeirdCat()
    {

    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {

    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(Pause());
    }
    private IEnumerator Pause()
    {
        //TODO: Add more sprites 

        animator.SetFloat("ChangeSpeed", 0f);

        yield return new WaitForSeconds(delay);

        animator.SetFloat("ChangeSpeed", 1f);
    }
    private void ShuffleForm()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            Sprite sprite = sprites[i];
            int randomNum = Random.Range(i, sprites.Count);
            sprites[i] = sprites[randomNum];
            sprites[randomNum] = sprite;
        }
    }
}
