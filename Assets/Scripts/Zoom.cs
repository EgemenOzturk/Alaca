using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 touchCamera;

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Debug.Log(Input.GetMouseButton(0));
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log(Camera.main.transform.position);

        if (!Input.GetMouseButton(1))
        {
            Debug.Log(Input.mouseScrollDelta);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + Input.mouseScrollDelta.x, Camera.main.transform.position.y - Input.mouseScrollDelta.y, Camera.main.transform.position.z);

        }

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;

    }

    //While converting to mobile use the touchInput commands
    private void Update()
    {
        
    }
}