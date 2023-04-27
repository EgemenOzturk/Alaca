using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public int width,height;

    Grid placementGrid;

    private Dictionary<Vector3Int, StructureModel> temporaryRoadObjects = new Dictionary<Vector3Int, StructureModel>();
    private Dictionary<Vector3Int, StructureModel> structureDictionary = new Dictionary<Vector3Int, StructureModel>();


    private void Start()
    {
        placementGrid = new Grid(width,height);
    }
    internal bool CheckIfPositionInBound(Vector3Int position)
    {
        if(position.x >= 0 && position.x < width && position.z >=0 && position.z < height)
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

    public void CheckDeleteGrid(Vector3Int position, int width = 1, int height = 1)
    {
        placementGrid[position.x, position.z] = CellType.Empty;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var newPosition = position + new Vector3Int(x, 0, z);
                placementGrid[newPosition.x, newPosition.z] = CellType.Empty;
                //Debug.Log("deleteObjects : newPosition.x, newPosition.z : " + newPosition.x + " + " + newPosition.z);
                structureDictionary.Remove(newPosition);
            }
        }
    }

    internal void PlaceTemporaryStructure(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        placementGrid[position.x, position.z] = type;
        StructureModel structure = CreateANewStructure(position, structurePrefab,type);
        temporaryRoadObjects.Add(position,structure);
    }

    private StructureModel CreateANewStructure(Vector3Int position, GameObject structurePrefab,CellType type)
    {
        GameObject structure = new GameObject(type.ToString());
        //structure.transform.SetParent(transform);
        structure.transform.localPosition = position;
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModel(structurePrefab);
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

    internal void PlaceObjectOnTheMap(Vector3Int position, GameObject prefab, CellType type,int width=1,int height=1)
    {
        StructureModel structure = CreateANewStructure(position, prefab, type);
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var newPosition = position + new Vector3Int(x, 0, z);
                placementGrid[newPosition.x, newPosition.z] = type;
                structureDictionary.Add(newPosition, structure);
            }
        }
    }
    internal void DestroyPlaceAt(Vector3Int position)
    {
        
    }

    
}
