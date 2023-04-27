using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
	public PlacementManager placementManager;

	public List<Vector3Int> temporaryPlacementPosition = new List<Vector3Int>();

    public List<Vector3Int> roadPositionsToRecheck = new List<Vector3Int>();


	RoadFixer roadFixer;

    private void Start()
    {
        roadFixer = GetComponent<RoadFixer>();
    }
    public void PlaceRoad(Vector3Int position)
	{
		if (placementManager.CheckIfPositionInBound(position) == false)
			return;
		if (placementManager.CheckIfPositionIsFree(position) == false)
			return;
        temporaryPlacementPosition.Clear();

        roadPositionsToRecheck.Clear();

        temporaryPlacementPosition.Add(position);

        placementManager.PlaceTemporaryStructure(position, roadFixer.roadStraight, CellType.Road);

        FixRoadPrefabs();

    }

    private void FixRoadPrefabs()
    {
        foreach(var temporaryPosition in temporaryPlacementPosition)
		{
			roadFixer.FixRoadAtPosition(placementManager,temporaryPosition);
			var neighbors = placementManager.GetNeighboursOfTypeFor(temporaryPosition, CellType.Road);
			foreach (var road in neighbors)
			{
				if (roadPositionsToRecheck.Contains(road) == false)
				{
					roadPositionsToRecheck.Add(road);
				}
				roadPositionsToRecheck.Add(road);
			}
		}
		foreach (var positionToFix in roadPositionsToRecheck)
		{
			roadFixer.FixRoadAtPosition(placementManager, positionToFix);
		}
    }
	
}
