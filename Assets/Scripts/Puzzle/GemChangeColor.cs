using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemChangeColor : MonoBehaviour
{
    [SerializeField] private Color CorrectColor;
    [SerializeField] private Color WrongColor;

    private Image GemImage;

    private void Awake()
    {
        GemImage = GetComponent<Image>();
    }

    public void ChangeColor(bool isCorrect)
    {
        if (isCorrect)
        {
            GemImage.color = CorrectColor;
        }
        else
        {
            GemImage.color = WrongColor;
        }
    }
}
