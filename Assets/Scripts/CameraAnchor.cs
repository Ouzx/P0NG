using System;
using System.Collections;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    
    private Camera cam;

    private float testRes = 0.5625f; // 9:16

    private float screenRatio;
    private void Start()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        cam.ResetProjectionMatrix();
        var m = cam.projectionMatrix;

        m.m00 *= screenRatio / testRes;
        cam.projectionMatrix = m;
    }
    

    // public SpriteRenderer ground;
    // void Start()
    // {
    //     float screenRatio = (float)Screen.width / (float)Screen.height;
    //     float targetRatio = ground.bounds.size.x / ground.bounds.size.y;

    //     if(screenRatio >= targetRatio)
    //     {
    //         Camera.main.orthographicSize = ground.bounds.size.y / 2;
    //     }
    //     else
    //     {
    //         float differenceInSize = targetRatio / screenRatio;
    //         Camera.main.orthographicSize = ground.bounds.size.y / 2 * differenceInSize;
    //     }
    // }

}

