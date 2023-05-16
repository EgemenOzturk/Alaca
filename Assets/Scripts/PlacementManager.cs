using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlacementManager : MonoBehaviour
{
    public int AllMapWidth,AllMapHeight;
    public int floorWidthForGround1, floorHeightForGround1, floorWidthForGround2, floorHeightForGround2;

    Grid placementGrid;

    private Dictionary<Vector3Int, StructureModel> temporaryRoadObjects = new Dictionary<Vector3Int, StructureModel>();
    private Dictionary<Vector3Int, StructureModel> structureDictionary = new Dictionary<Vector3Int, StructureModel>();


    private void Start()
    {
        placementGrid = new Grid(AllMapWidth,AllMapHeight);
    }
    internal bool CheckIfPositionInBound(Vector3Int position)
    {
        if(position.x >= 0 && position.x < AllMapWidth && position.z >=0 && position.z < AllMapHeight)
            return true;
        return false;
    }

    internal bool CheckIfPositionIsFree(Vector3Int position)
    {
        return CheckIfPositionIsOfType(position,CellType.Empty);
    }

    private bool CheckIfPositionIsOfType(Vector3Int position,CellType type)
    {
        return placementGrid[position.x, position.z] == type;
    }
    internal void PlaceTemporaryStructureRoad(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        placementGrid[position.x, position.z] = type;
        StructureModel structure = CreateANewStructureRoad(position, structurePrefab, type);
        temporaryRoadObjects.Add(position, structure);
    }
    internal void PlaceTemporaryStructure(Vector3Int position, GameObject structurePrefab, CellType type, StructureData data)
    {
        placementGrid[position.x, position.z] = type;
        StructureModel structure = CreateANewStructure(position, structurePrefab,type,data);
        temporaryRoadObjects.Add(position,structure);
    }
    private StructureModel CreateANewStructureRoad(Vector3Int position, GameObject structurePrefab, CellType type, float yAxis = 0f)
    {
        GameObject structure = new GameObject(type.ToString());
        //structure.transform.SetParent(transform);
        structure.transform.localPosition = new Vector3(position.x, yAxis, position.z);
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModelRoad(structurePrefab);

        return structureModel;
    }
    private StructureModel CreateANewStructure(Vector3Int position, GameObject structurePrefab, CellType type, StructureData data, float yAxis = 0f)
    {
        GameObject structure = new GameObject(type.ToString());
        //structure.transform.SetParent(transform);
        structure.transform.localPosition = new Vector3(position.x, yAxis, position.z);
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModel(structurePrefab, data,yAxis);

        return structureModel;
    }

    private StructureModel CreateANewStructureOnSea(Vector3Int position, GameObject structurePrefab, StructureData data, CellType type,float yAxis)
    {
        GameObject structure = new GameObject(type.ToString());
        //structure.transform.SetParent(transform);
        structure.transform.localPosition = new Vector3(position.x, yAxis, position.z);
      
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModel(structurePrefab,data,yAxis);
        return structureModel;
    }
    public void ModifiedStructureModel(Vector3Int position,GameObject newModel,Quaternion rotation)
    {
        if(temporaryRoadObjects.ContainsKey(position))
        {
            temporaryRoadObjects[position].SwapModel(newModel, rotation);
        }
    }

    internal CellType[] GetNeighbourTypesFor(Vector3Int position)
    {
        return placementGrid.GetAllAdjacentCellTypes(position.x, position.z);
    }

    internal List<Vector3Int> GetNeighboursOfTypeFor(Vector3Int temporaryPosition, CellType type)
    {
        var neighborVertices = placementGrid.GetAdjacentCellsOfType(temporaryPosition.x, temporaryPosition.z, type);
        List<Vector3Int> neighbots = new List<Vector3Int>();
        foreach (var point in neighborVertices)
        {
            neighbots.Add(new Vector3Int(point.X, 0, point.Y));
        }
        return neighbots;
    }
    internal void PlaceObjectOnTheMap(Vector3Int position, GameObject prefab, CellType type, StructureData data, int width=1,int height=1 )
    {
        float yAxis = 0;
        if (Mountain1Placement(position))
        {
            yAxis = 11.5f;
        }
        else if (Mountain2Placement(position))
        {
            yAxis = 7.5f;
        } 
        else if (Mountain3Placement(position))
        {
            yAxis = 4.5f;
        }
            
        else if (CheckIsBehindHills(position))
        {
            yAxis = 2f;
        }
            
        StructureModel structure = CreateANewStructure(position, prefab, type,data,yAxis);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var newPosition = position + new Vector3Int(x, (int)yAxis, z);
                placementGrid[newPosition.x, newPosition.z] = type;
                structureDictionary.Add(newPosition, structure);
            }
        }
    } 
    internal void PlaceObjectOnTheSea(Vector3Int position, GameObject prefab, CellType type, StructureData data, int width = 1, int height = 1,float yAxis=1.5f)
    {
        StructureModel structure = CreateANewStructureOnSea(position, prefab,data, type, yAxis);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var newPosition = position + new Vector3Int(x, -1, z);
                placementGrid[newPosition.x, newPosition.z] = type;
                structureDictionary.Add(newPosition, structure);
            }
        }
    }
    internal void DestroyPlaceAt(Vector3Int position)
    {
        bool temp=false;

        RaycastHit[] roads = Physics.BoxCastAll(position +
            new Vector3(0, 0.2f, 0),
            new Vector3(0.1f, 0.1f, 0.1f),
            transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Roads"));

        foreach (var item in roads)
        {
            var foo = item.collider.transform.root.gameObject;
            if (!temp)
            {
                RemoveGrids(item.collider.transform.root.gameObject.GetComponent<StructureModel>().GetLocationsFor(1, 1));
                temp = true;
            }
            transform.parent = null;
            Destroy(foo);
        }

        //For Building 1x1 areas
        RaycastHit[] hits = Physics.BoxCastAll(position +
            new Vector3(0, 0.2f, 0),
            new Vector3(0.1f, 0.1f, 0.1f),
            transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Building/1x1"));

        foreach (var item in hits)
        {
            var foo = item.collider.transform.root.gameObject;
            if (!temp)
            {
                RemoveGrids(item.collider.transform.root.gameObject.GetComponent<StructureModel>().GetLocationsFor(1,1));
                temp = true;
            }
            transform.parent = null;
            Destroy(foo);
        }

        //For Building 2x2 areas
        RaycastHit[] hits2 = Physics.BoxCastAll(position +
            new Vector3(0, 0.5f, 0),
            new Vector3(0.5f, 0.5f, 0.5f),
            transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Building/2x2"));

        foreach (var item in hits2)
        {
            var foo = item.collider.transform.root.gameObject;
            if (!temp)
            {
                RemoveGrids(item.collider.transform.root.gameObject.GetComponent<StructureModel>().GetLocationsFor(2,2));
                temp = true;
            }
            
            transform.parent = null;
            Destroy(foo);
        }

        //For Building 4x4 areas
        RaycastHit[] hits3 = Physics.BoxCastAll(position +
            new Vector3(0, 0.5f, 0),
            new Vector3(0.5f, 0.5f, 0.5f),
            transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Building/4x4"));

        foreach (var item in hits3)
        {
            var foo = item.collider.transform.root.gameObject;
            if (!temp)
            {
                RemoveGrids(item.collider.transform.root.gameObject.GetComponent<StructureModel>().GetLocationsFor(4, 4));
                temp = true;
            }
            transform.parent = null;
            Destroy(foo);
        }

        //For Building 6x6 areas
        RaycastHit[] hits4 = Physics.BoxCastAll(position +
            new Vector3(0, 0.5f, 0),
            new Vector3(0.5f, 0.5f, 0.5f),
            transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Building/6x6"));

        foreach (var item in hits4)
        {
            var foo = item.collider.transform.root.gameObject;
            if (!temp)
            {
                RemoveGrids(item.collider.transform.root.gameObject.GetComponent<StructureModel>().GetLocationsFor(6,6));
                temp = true;
            }
            transform.parent = null;
            Destroy(foo);
        }

    }

    private void RemoveGrids(List<Vector3> vector3s)
    {
        foreach (Vector3 pos in vector3s)
        {
            placementGrid[(int)pos.x, (int)pos.z] = CellType.Empty;
        }
    }

    internal bool CheckInSea(Vector3Int position, int Objectwidth, int Objectheight)
    {
        if (position.x >= 0 && position.x <=84 && position.z >= 44 && position.z <= 89)
        {
            return true;
        }
        return false;
    }
    internal bool CheckInStream(Vector3Int position, int Objectwidth, int Objectheight)
    {
        if (position.x >= 75 && position.x <= 84 && position.z >= 1 && position.z <=44)
        {
            return true;
        }
        return false;
    }

    internal bool CheckInFloor(Vector3Int position)
    {

        if ((position.x >= 64 && position.x <= 74 && position.z >= 0 && position.z <= 44) || (position.x >= 0 && position.x <= 74 && position.z >= 36 && position.z <= 44))
        {
            return true;
        }
        if (position.x >= 85 && position.x <= 127 && position.z >= 0 && position.z <= 58)
        {
            return true;
        }
        if (Mountain1Placement(position))
            return true;
        if (Mountain2Placement(position))
            return true;
        if (Mountain3Placement(position))
            return true;
        if(CheckIsBehindHills(position)) 
            return true;

        return false;
    }
    internal bool CheckIsBehindHills(Vector3Int position)
    {
        if (position.x >= 0 && position.x <= 74 && position.z >= 114 && position.z <= 135)
        {
            Debug.Log("CheckIsBehindHills");
            return true;
        }
        return false;
    }
    internal bool CheckIsMountain(Vector3Int position)
    {
        if(Mountain1Placement(position))
            return true;
        if (Mountain2Placement(position))
            return true;
        if (Mountain3Placement(position))
            return true;
        return false;
    }
    internal bool Mountain1Placement(Vector3Int position)
    {
        if(position.x >= 109 && position.x <= 115 && position.z >=77 && position.z <= 86)
        {
            return true;
        }
        return false;
    }
    internal bool Mountain2Placement(Vector3Int position)
    {
        if (position.x >= 96 && position.x <= 103 && position.z >= 74 && position.z <= 81)
        {
            return true;
        }
        return false;
    }
    internal bool Mountain3Placement(Vector3Int position)
    {
        if (position.x >= 107 && position.x <= 116 && position.z >= 67 && position.z <= 73)
        {
            return true;
        }
        return false;
    }
}
