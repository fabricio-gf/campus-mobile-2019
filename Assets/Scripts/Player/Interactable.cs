using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected static string dataPath = string.Empty;

    abstract public void Interact();
}
