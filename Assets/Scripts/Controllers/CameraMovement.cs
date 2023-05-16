
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS
{

    public class CameraMovement : MonoBehaviour
    {
        private Camera gameCamera;
        public float cameraMovementSpeed = 5f;
        public float cameraZoomSpeed = 2f;
        public float maxZoom = 10f;
        public float minZoom = 1f;


        private void Start()
        {
            gameCamera = GetComponent<Camera>();
        }
        public void MoveCamera(Vector3 inputVector)
        {
            var movementVector = Quaternion.Euler(0,30,0) * inputVector;
            gameCamera.transform.position += movementVector * Time.deltaTime * cameraMovementSpeed;
        }
        private void Update()
        {
            // Zoom in/out with mouse wheel
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            gameCamera.orthographicSize = Mathf.Clamp(gameCamera.orthographicSize - scrollInput * cameraZoomSpeed, minZoom, maxZoom);
        }
    }
}