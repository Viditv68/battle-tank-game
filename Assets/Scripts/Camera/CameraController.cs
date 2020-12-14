using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    private Camera camera;
    private Vector3 cameraOffset;

    [Range(0.1f, 1.0f)]
    public float smoothFactor;
    
   

    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        cameraOffset = transform.position - playerTransform.position;

    }

 
    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position - cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
