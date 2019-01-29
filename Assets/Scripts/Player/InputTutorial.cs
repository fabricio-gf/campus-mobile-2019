using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorial : MonoBehaviour
{

    [SerializeField] private int ProgressLimit = 0;


    // Start is called before the first frame update
    void Awake()
    {
        if(ProgressLimit > ProgressDataManager.CurrentProgress)
        {
            Destroy(gameObject);
        }
        else
        {
            //StartCoroutine(StartDelay());
        }
    }

    public void CloseTutorial()
    {
        //set animation to close
        ProgressDataManager.SetProgress(ProgressLimit+1);
    }
}
