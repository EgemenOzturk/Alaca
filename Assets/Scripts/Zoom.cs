using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;
    private bool drag = false;
    private bool zoomInTrue = false;

    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        Debug.Log(Input.GetMouseButton(0));
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log(Camera.main.transform.position);

        if (Input.GetMouseButton(0))
        {
            if(zoomInTrue)
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -1))) - Camera.main.transform.position;
            else
                Difference = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1))) - Camera.main.transform.position;

            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference * 0.5f;
        }

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;

    }

    public void setZoom()
    {
        if(zoomInTrue)
        {
            zoomInTrue = false;
        }
        else
        {
            zoomInTrue = true;
        }
    }
}