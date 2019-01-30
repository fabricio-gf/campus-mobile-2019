using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemChangeColor : MonoBehaviour
{
    [SerializeField] private Sprite CorrectColor = null;
    [SerializeField] private Sprite WrongColor = null;

    private Image GemImage;

    private void Awake()
    {
        GemImage = GetComponent<Image>();
    }

    public void ChangeColor(bool isCorrect)
    {
        if (isCorrect)
        {
            GemImage.sprite = CorrectColor;
        }
        else
        {
            GemImage.sprite = WrongColor;
        }
    }
}
