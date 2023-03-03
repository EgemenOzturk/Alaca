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

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Debug.Log(Input.GetMouseButton(0));
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log(Camera.main.transform.position);

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;   
        if(!Input.GetMouseButton(1) && Input.mouseScrollDelta.y != 0)
        {
            Debug.Log("Mous");
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Input.mouseScrollDelta.y, Camera.main.transform.position.z);
            camPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Input.mouseScrollDelta.y, Camera.main.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetMouseButton(0))
        {
            //transform.SetPositionAndRotation(new Vector3(Input.GetAxis("Mouse Y") * 100, camPos.y, -Input.GetAxis("Mouse X") * 100), Camera.main.transform.rotation);
            //X = transform.rotation.eulerAngles.x;
            //Y = transform.rotation.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(X, Y, 0);

            //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0));
            //transform.position.Set(Input.GetAxis("Mouse Y"), camPos.y, -Input.GetAxis("Mouse X"));
            //Y = transform.rotation.eulerAngles.y;
            //transform.position = Quaternion.Euler(X, Y, 0);

            //transform.position = new Vector3(Input.GetAxis("Mouse Y"), camPos.y, -Input.GetAxis("Mouse X"));

            Debug.Log(Input.GetAxis("Mouse X"));



            transform.Translate(new Vector3(Input.GetAxis("Mouse X"), camPos.y, Input.GetAxis("Mouse Y")));
            X = transform.position.x; 
            Y = transform.position.y;
            transform.position = new Vector3(Input.GetAxis("Mouse X") * 5, camPos.y, Input.GetAxis("Mouse Y") * 5);

            //camPos.x = X;
            //X = transform.position.x;
            //transform.position = new Vector3(X, camPos.y, camPos.z);
        }

    }    
}