using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    public float zoomSpeed = 5;
    public float targetOrtho;
    public float smoothSpeed = 20.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 200.0f;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}
