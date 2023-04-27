using SVS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;

    public RoadManager roadManager;

    public InputManager inputManager;

    public UIController uIController;

    public StructureManager structureManager;
    private void Start()
    {
        uIController.OnRoadPlacement += RoadPlacementHandler;
        uIController.OnHousePlacement += HousePlacementHandler;
        uIController.OnSpecialPlacement += SpecialPlacementHandler;
        uIController.OnBigSturcturePlacement += BigPlacementHandler;
        uIController.OnDeleteObject += DestroySelectedObject;
    }

    private void DestroySelectedObject()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.DestroySelected;
    }
    private void BigPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceBigStructure;
    }

    private void SpecialPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceSpecial;
    }

    private void HousePlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += structureManager.PlaceHouse;
    }

    private void RoadPlacementHandler()
    {
        ClearInputActions();
        inputManager.OnMouseClick += HandleMouseClick;
        inputManager.OnMouseHold += HandleMouseClick;
    }

    private void ClearInputActions()
    {
        inputManager.OnMouseClick = null;
        inputManager.OnMouseHold = null;
    }

    private void HandleMouseClick(Vector3Int position)
    {
        
        roadManager.PlaceRoad(position);
    }
    private void Update()
    {
        cameraMovement.MoveCamera(
            new Vector3(
                inputManager.CameraMovementVector.x,
            0,
            inputManager.CameraMovementVector.y
            ));
    }
}
