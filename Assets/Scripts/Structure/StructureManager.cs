using SVS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public class StructureManager : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField]
    private PlacementManager placementManager;
    [SerializeField]
    private MoneyController moneyController;
    [SerializeField]
    private TextMeshProUGUI errorText;
    [Header("Scriptable Objects")]
    [SerializeField]
    private StructureData windmillData;
    [SerializeField]
    private StructureData solarPanelData;
    [SerializeField]
    private StructureData smallPowerPlantData;
    [SerializeField]
    private StructureData nuclearPowerPlantData;
    [SerializeField]
    private StructureData nuclearPowerPlant2Data;
    [SerializeField]
    private StructureData pottedPowerPlantData;
    [SerializeField]
    private StructureData coalPowerPlantData;
    [SerializeField]
    private StructureData geotermalPowerStation;
    [SerializeField]
    private StructureData geotermalPowerStationUnder;
    [SerializeField]
    private StructureData wawePanelData;
    [SerializeField]
    private StructureData hydroElectricData;
    [SerializeField]
    private StructureData treeData;
    [SerializeField]
    private StructureData apartmentData;
    [SerializeField]
    private StructureData flatHouseData;
    [SerializeField]
    private StructureData housesData;

    public StructurePrefabWeighted windmillPrefab, solarPanelPrefab,small_power_plant_2x2_Prefab, NuclearPowerPlantPrefab, 
        NuclearPowerPlant2Prefab,PottedPowerPlantPrefab, CoalPowerPlantPrefab, WawePanelPrefab,GeotermalPowerStationPrefab, GeotermalPowerStationUnderPrefab, 
        HydroElectricPrefab,Tree1Prefab,Tree2Prefab, Tree3Prefab, Tree4Prefab, Tree5Prefab, FlatHouse1Prefab, FlatHouse2Prefab, House1Prefab, House2Prefab, 
        House3Prefab,Apartment2Prefab;

    private bool isBuildable;

    private void Start()
    {
        errorText.text = "";
    }
    public void PlaceWindmill(Vector3Int position)
    {
        GeneralFunctionForGround(windmillPrefab,windmillData,position);
    }
    internal void PlaceSolarPanel(Vector3Int position)
    {
        GeneralFunctionForGround(solarPanelPrefab,solarPanelData,position);
    }

    internal void small_power_plant_2x2_Panel(Vector3Int position)
    {
        GeneralFunctionForGround(small_power_plant_2x2_Prefab,smallPowerPlantData,position);
    }

    internal void NuclearPowerPlantPanel(Vector3Int position)
    {
        GeneralFunctionForGround(NuclearPowerPlantPrefab,nuclearPowerPlantData,position);
    }

    internal void NuclearPowerPlant2Panel(Vector3Int position)
    {
        GeneralFunctionForGround(NuclearPowerPlant2Prefab,nuclearPowerPlant2Data, position);
    }
    internal void CoalPowerPlant2Panel(Vector3Int position)
    {
        GeneralFunctionForGround(CoalPowerPlantPrefab,coalPowerPlantData,position);
    }
   
    internal void PottedPowerPlant2Panel(Vector3Int position)
    {
        GeneralFunctionForGround(PottedPowerPlantPrefab,pottedPowerPlantData,position);
    }

    internal void WawePanel(Vector3Int position)
    {
        GeneralFunctionForSea(WawePanelPrefab,wawePanelData,position);
    }
    internal void GeotermalPowerStation(Vector3Int position)
    {
        GeneralFunctionForGround(GeotermalPowerStationPrefab, geotermalPowerStation, position);
    }
    internal void GeotermalPowerStationUnder(Vector3Int position)
    {
        GeneralFunctionForGround(GeotermalPowerStationUnderPrefab, geotermalPowerStationUnder, position);
    }
    internal void HydroElectricPanel(Vector3Int position)
    {
        GeneralFunctionForStream(HydroElectricPrefab,hydroElectricData,position);
    }
    internal void Tree1(Vector3Int position)
    {
        GeneralFunctionForGround(Tree1Prefab,treeData, position);
    }
    internal void Tree2(Vector3Int position)
    {
        GeneralFunctionForGround(Tree2Prefab, treeData, position);
    }
    internal void Tree3(Vector3Int position)
    {
        GeneralFunctionForGround(Tree3Prefab, treeData, position);
    }
    internal void Tree4(Vector3Int position)
    {
        GeneralFunctionForGround(Tree4Prefab, treeData, position);
    }
    internal void Tree5(Vector3Int position)
    {
        GeneralFunctionForGround(Tree5Prefab, treeData, position);
    }
    public void FlatHouse1(Vector3Int position)
    {
        GeneralFunctionForGround(FlatHouse1Prefab,flatHouseData,position);
    }
    public void FlatHouse2(Vector3Int position)
    {
        GeneralFunctionForGround(FlatHouse2Prefab, flatHouseData, position);
    }
    public void House1(Vector3Int position)
    {
        GeneralFunctionForGround(House1Prefab, housesData, position);
    }
    public void House2(Vector3Int position)
    {
        GeneralFunctionForGround(House2Prefab, housesData, position);
    }
    public void House3(Vector3Int position)
    {
        GeneralFunctionForGround(House3Prefab, housesData, position);
    }
    public void Apartment2(Vector3Int position)
    {
        GeneralFunctionForGround(Apartment2Prefab, apartmentData, position);
    }
    private void GeneralFunctionForGround(StructurePrefabWeighted prefab,StructureData data, Vector3Int position)
    {
        int width = prefab.area;
        int height = prefab.area;
        if (CheckBigStructure(position,width,height) && placementManager.CheckInFloor(position) && PlayerPrefs.GetInt("Money") >= data.cost)
        {
            placementManager.PlaceObjectOnTheMap(position, prefab.prefab, CellType.Structure, data, width, height);
            AudioPlayer.instance.PlayPlacementSound();
        }
    }
    private void GeneralFunctionForStream(StructurePrefabWeighted prefab, StructureData data, Vector3Int position)
    {
        int width = prefab.area;
        int height = prefab.area;
        if (placementManager.CheckInStream(position, width, height) && DefaultCheck(position) && PlayerPrefs.GetInt("Money") >= data.cost)
        {
            placementManager.PlaceObjectOnTheSea(position, prefab.prefab, CellType.Structure,data, width, height, -1.5f);
            AudioPlayer.instance.PlayPlacementSound();
        }
    }
    private void GeneralFunctionForSea(StructurePrefabWeighted prefab, StructureData data, Vector3Int position)
    {
        int width = prefab.area;
        int height = prefab.area;
        if (placementManager.CheckInSea(position, width, height) && DefaultCheck(position) && PlayerPrefs.GetInt("Money") >= data.cost)
        {
            //StructureSystem(data);
            placementManager.PlaceObjectOnTheSea(position, prefab.prefab, CellType.Structure, data,width, height, -1.5f);
            AudioPlayer.instance.PlayPlacementSound();
        }
    }

    internal void DestroySelected(Vector3Int position)
    {
        placementManager.DestroyPlaceAt(position);
    }
    private bool CheckBigStructure(Vector3Int position, int width, int height)
    {
        bool nearRoad=true;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newPosition = position + new Vector3Int(i, 0, j);
               
                if (DefaultCheck(newPosition) == false)
                {
                    isBuildable = false;
                    nearRoad = false;
                }
            }
        }
        return nearRoad;
    }
    private bool CheckPositionBeforePlacement(Vector3Int position)
    {
        if (DefaultCheck(position) == false)
        {
            isBuildable = false;
            return false;
        }


        if (RoadCheck(position) == false)
        {
            isBuildable = false;
            return false;
        }
        isBuildable = false;
        return true;
    }

    private bool RoadCheck(Vector3Int position)
    {

        if (placementManager.GetNeighboursOfTypeFor(position, CellType.Road).Count() == 0)
        {
            StartCoroutine(textNumarator("Must be placed near a road"));
            isBuildable = false;
            return false;
        }
        isBuildable = true;
        return true;
    }
    private bool DefaultCheck(Vector3Int position)
    {
        if (placementManager.CheckIfPositionInBound(position) == false)
        {
            Debug.Log("This position is out of bounds");
            isBuildable = false;
            StartCoroutine(textNumarator("This position is out of bounds"));
            return false;
        }
        if (placementManager.CheckIfPositionIsFree(position) == false)
        {
            Debug.Log("This position is already taken");
            isBuildable = false;
            StartCoroutine(textNumarator("This position is already taken"));
            return false;
        }
        isBuildable = true;
        return true;
    }
    IEnumerator textNumarator(String text)
    {
        errorText.text = text;
        errorText.color = Color.black;
        yield return new WaitForSeconds(3);
        errorText.text = "";
    }

    public bool GetIsBuildable()
    {
        return isBuildable;
    }

    
}

[Serializable]
public struct StructurePrefabWeighted
{
    public GameObject prefab;
    public int area;
}