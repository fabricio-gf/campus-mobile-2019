using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerArrow : MonoBehaviour
{
    [SerializeField] private RectTransform Content = null;
    [SerializeField] private float FadeLimit = 0;
    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Content.anchoredPosition.y >= FadeLimit)
        {
            animator.SetBool("Fade", false);
        }
        else
        {
            animator.SetBool("Fade", true);
        }
    }
}
