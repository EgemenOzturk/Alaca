using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 camPos;
    private float X;
    private float Y;
    public int cameraDragSpeed = 500;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float speed = cameraDragSpeed * Time.deltaTime;
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, 0, Input.GetAxis("Mouse Y") * speed);
        }
    }


    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;   
        if(!Input.GetMouseButton(1) && Input.mouseScrollDelta.y != 0)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Input.mouseScrollDelta.y, Camera.main.transform.position.z);
            camPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Input.mouseScrollDelta.y, Camera.main.transform.position.z);
        }
    }    
}