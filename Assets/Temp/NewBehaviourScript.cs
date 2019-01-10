using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private int ImpassableLayerIndex;

    // Start is called before the first frame update
    void Start()
    {
        ImpassableLayerIndex = LayerMask.NameToLayer("Impassable");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, ImpassableLayerIndex);
        print(hit.point);
        if (hit)
        {
            print("hit");
        }
    }
}
