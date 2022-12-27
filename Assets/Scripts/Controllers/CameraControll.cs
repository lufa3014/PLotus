using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector3 CameraPosition;

    [Header("Camera Settings")]
    public float CameraSpeed = 1f;

    void Start()
    {
        CameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.y += CameraSpeed / 10;
        }

        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.y -= CameraSpeed / 10;
        }

        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= CameraSpeed / 10;
        }

        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += CameraSpeed / 10;
        }


        this.transform.position = CameraPosition;

    }
}
