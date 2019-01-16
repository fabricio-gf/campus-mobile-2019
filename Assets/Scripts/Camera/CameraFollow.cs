using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // PRIVATE REFERENCES
    private Camera mainCamera;
    private Transform Target = null;
    [SerializeField] private BoxCollider2D cameraBounds = null;

    // PRIVATE ATTRIBUTES
    private float cameraHalfWidth;
    private Vector3 min, max;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.15f;


    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        min = cameraBounds.bounds.min;
        max = cameraBounds.bounds.max;

        // ortographicSize is the haldf of the height of the Camera.
        cameraHalfWidth = mainCamera.orthographicSize * ((float)Screen.width / Screen.height);
    }

    void FixedUpdate()
    //void Update()
    {
        if (Target)
        {
            Vector3 targetPosition = Target.position;
            targetPosition.z = -10;

            Vector3 currentPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            float x = currentPosition.x;
            float y = currentPosition.y;
            x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, min.y + mainCamera.orthographicSize, max.y - mainCamera.orthographicSize);

            transform.position = new Vector3(x, y, transform.position.z);
            //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }
        else
        {
            Transform tr = GameObject.FindGameObjectWithTag("Player").transform;
            if (tr)
            {
                Target = tr;
                transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            }
        }
    }
}
