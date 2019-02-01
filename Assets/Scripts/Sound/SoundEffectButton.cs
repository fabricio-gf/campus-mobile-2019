using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectButton : MonoBehaviour
{
    private SFXController controller = null;
    private Button button = null;

    [Tooltip("Possible keys: PressButton - ToggleWindow - CorrectAnswer - WrongAnswer - FlipPage")]
    [SerializeField] private string Effect = string.Empty;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("SoundSource").GetComponent<SFXController>();
        button = GetComponent<Button>();
        if(controller) button.onClick.AddListener(() => controller.PlayClip(Effect));
    }
}
