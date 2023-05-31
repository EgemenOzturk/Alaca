using geyikgames.unity.popup;
using SVS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    [Header("Controllers")]
    public CameraMovement cameraMovement;

    public RoadManager roadManager;

    public InputManager inputManager;

    public UIController uIController;

    public StructureManager structureManager;

    public PreviewSystem previewSystem;

    private int sentinel = 0;
    private int sentinel2 = 0;
    int oldMonth = 0;


    [SerializeField] public GameObject timerText;
    [SerializeField] public InGameUIController gameUICont;
    [SerializeField] public GameObject box1;
    [SerializeField] public GameObject box2;
    [SerializeField] public GameObject box3;
    [SerializeField] public GameObject cancelB;
    public float dayCount;
    public int monthCount;
    public int yearCount;
    private int i;

    public void UpdateTimerUI()
    {
        //set timer UI
        dayCount += Time.deltaTime;

        if (monthCount != oldMonth)
        {
            Debug.Log(dayCount + "NIG");
            i = UnityEngine.Random.Range(0, 16);
            PopupController.Instance.Open<TestEventPopup>("TestEventPopup", (popup) =>
            {
                popup.Initialize(i);
            });
            oldMonth++;
        }

        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("BuildData.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("build");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            mydoc.SelectSingleNode("build/daySet").InnerText = dayCount.ToString();
            mydoc.SelectSingleNode("build/monthSet").InnerText = monthCount.ToString();
            mydoc.SelectSingleNode("build/yearSet").InnerText = yearCount.ToString();
            mydoc.Save("BuildData.xml");
        }

        timerText.GetComponent<TMP_Text>().text = "Year:" + yearCount + "   Month:" + (monthCount + 1) + "   Day:" + (int)(dayCount);
        if (dayCount >= 30)
        {
            monthCount++;
            dayCount %= 30;
        }
        else if (monthCount >= 12)
        {
            yearCount++;
            monthCount %= 12;
        }

        if(oldMonth >= 12)
            oldMonth %= 12;
    }

    public StructurePrefabWeighted windmillPrefab, solarPanelPrefab, small_power_plant_2x2_Prefab, NuclearPowerPlantPrefab,
        NuclearPowerPlant2Prefab, PottedPowerPlantPrefab, CoalPowerPlantPrefab,GeotermalPowerPlantPrefab, GeotermalPowerPlantUnderPrefab, 
        WawePanelPrefab, HydroElectricPrefab,Tree1Prefab,Tree2Prefab,Tree3Prefab,Tree4Prefab,Tree5Prefab, FlatHouse1Prefab, FlatHouse2Prefab,
        House1Prefab, House2Prefab, House3Prefab, Apartment2Prefab;
    private void Awake()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("BuildData.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("build");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            dayCount = float.Parse(mydoc.SelectSingleNode("build/daySet").InnerText.Trim());
            monthCount = int.Parse(mydoc.SelectSingleNode("build/monthSet").InnerText.Trim());
            yearCount = int.Parse(mydoc.SelectSingleNode("build/yearSet").InnerText.Trim());
            oldMonth = (int.Parse(mydoc.SelectSingleNode("build/monthSet").InnerText.Trim()) - 1) % 12;
        }

        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("GoldEnergy.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("currency");

        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
        {
            //mydoc2.SelectSingleNode("currency/gold").InnerText = PlayerPrefs.GetInt("Money").ToString();
            //mydoc2.Save("GoldEnergy.xml");
            PlayerPrefs.SetInt("Money", int.Parse(mydoc2.SelectSingleNode("currency/gold").InnerText));
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", int.Parse(mydoc2.SelectSingleNode("currency/gold").InnerText));
        }
        if (PlayerPrefs.HasKey("Pollution"))
        {
            PlayerPrefs.SetInt("Pollution", 0);
        }
        Debug.Log("Moneys: " + PlayerPrefs.GetInt("Money"));
        Debug.Log("Pollutions: " + PlayerPrefs.GetInt("Pollution"));
    }
    private void Start()
    {
        uIController.OnRoadPlacement += RoadPlacementHandler;
        uIController.OnDeleteObject += DestroySelectedObject;
        uIController.OnWindmillPlacement+= WindmillPlacementHandler;
        uIController.OnSolarPanelPlacement+= SolarPanelPlacementHandler;
        uIController.OnSmall_power_plant_2x2_Placement+= small_power_plant_2x2_PlacementHandler;
        uIController.OnNuclearPowerPlantPlacement+= NuclearPowerPlantPlacementHandler;
        uIController.OnNuclearPowerPlant2Placement+= NuclearPowerPlant2PlacementHandler;
        uIController.OnPottedPowerPlantPlacement += PottedPowerPlant2PlacementHandler;
        uIController.OnCoalPowerPlantButton += CoalPowerPlant2PlacementHandler;
        uIController.OnGeotermalPowerPlantPrefab += GeotermalPowerPlantPlacementHandler;
        uIController.OnGeotermalPowerPlantUnderPrefab += GeotermalPowerPlantUnderPlacementHandler;
        uIController.OnWawePanel += WawePanelPlacementHandler;
        uIController.OnHydroelectricPanel += HydroElectricPanelPlacement;
        uIController.OnTree1Panel += Tree1PanelPlacement;
        uIController.OnTree2Panel+= Tree2PanelPlacement;
        uIController.OnTree3Panel += Tree3PanelPlacement;
        uIController.OnTree4Panel += Tree4PanelPlacement;
        uIController.OnTree5Panel += Tree5PanelPlacement;
        uIController.OnFlatHouse1Panel += FlatHouse1PanelPlacement;
        uIController.OnFlatHouse1Panel += FlatHouse2PanelPlacement;
        uIController.OnHouse1Panel+= House1PanelPlacement;
        uIController.OnHouse2Panel+= House2PanelPlacement;
        uIController.OnHouse3Panel+= House3PanelPlacement;
        uIController.OnApartment2Panel+= Apartment2PanelPlacement;
    }

    private void FixedUpdate()
    {
        Debug.Log(sentinel);
    }

    private void DestroySelectedObject()
    {
        ClearInputActions();
        if(sentinel > 0)
            previewSystem.StopShowingPreview();
            sentinel= 0;
        inputManager.OnMouseClick += structureManager.DestroySelected;
        //if(sentinel > 0)
          //  inputManager.OnMouseClick += sentinelDec();
    }

    internal Action<Vector3Int> sentinelInc()
    {
        sentinel++;
        return null;
    }

    internal Action<Vector3Int> sentinelDec()
    {
        sentinel--;
        return null;
    }

    private void RoadPlacementHandler()
    {
        sentinel++;
        ClearInputActions();

        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("GoldEnergy.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("currency");

        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
        {
            //mydoc2.SelectSingleNode("currency/gold").InnerText = PlayerPrefs.GetInt("Money").ToString();
            //mydoc2.Save("GoldEnergy.xml");
            PlayerPrefs.SetInt("Money", int.Parse(mydoc2.SelectSingleNode("currency/gold").InnerText) - 5);
            mydoc2.SelectSingleNode("currency/gold").InnerText = PlayerPrefs.GetInt("Money").ToString();
            mydoc2.Save("GoldEnergy.xml");
        }

        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        inputManager.OnMouseClick += HandleMouseClick;
        inputManager.OnMouseHold += HandleMouseClick; 

    }

    private void WindmillPlacementHandler()
    {
        sentinel++;
        ClearInputActions();

        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        previewSystem.StartShowingPlacementPreview(windmillPrefab.prefab, windmillPrefab.area);

        if(PlayerPrefs.GetInt("Money") - 100 >= 0)
        {
            inputManager.OnMouseClick += structureManager.PlaceWindmill;
        }


    }
    private void SolarPanelPlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(solarPanelPrefab.prefab, solarPanelPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 200 >= 0)
        {
            inputManager.OnMouseClick += structureManager.PlaceSolarPanel;
        }

    }
    private void small_power_plant_2x2_PlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(small_power_plant_2x2_Prefab.prefab,small_power_plant_2x2_Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 400 >= 0)
        {
            inputManager.OnMouseClick += structureManager.small_power_plant_2x2_Panel;
        }
    }
    private void NuclearPowerPlantPlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(NuclearPowerPlantPrefab.prefab,NuclearPowerPlantPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 1000 >= 0)
        {
            inputManager.OnMouseClick += structureManager.NuclearPowerPlantPanel;
        }
    }
    private void NuclearPowerPlant2PlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(NuclearPowerPlant2Prefab.prefab,NuclearPowerPlant2Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 1200 >= 0)
        {
            inputManager.OnMouseClick += structureManager.NuclearPowerPlant2Panel;
        }
    }
    private void PottedPowerPlant2PlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(PottedPowerPlantPrefab.prefab,PottedPowerPlantPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 500 >= 0)
        {
            inputManager.OnMouseClick += structureManager.PottedPowerPlant2Panel;
        }
    }
    private void CoalPowerPlant2PlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(CoalPowerPlantPrefab.prefab,CoalPowerPlantPrefab.area,true);
        if (PlayerPrefs.GetInt("Money") - 400 >= 0)
        {
            inputManager.OnMouseClick += structureManager.CoalPowerPlant2Panel;
        }
    }
    private void WawePanelPlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(WawePanelPrefab.prefab,WawePanelPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 300 >= 0)
        {
            inputManager.OnMouseClick += structureManager.WawePanel;
        }
    }
    
    private void GeotermalPowerPlantPlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(GeotermalPowerPlantPrefab.prefab, GeotermalPowerPlantPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 600 >= 0)
        {
            inputManager.OnMouseClick += structureManager.GeotermalPowerStation;
        }
    }
    private void GeotermalPowerPlantUnderPlacementHandler()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(GeotermalPowerPlantUnderPrefab.prefab, GeotermalPowerPlantUnderPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 600 >= 0)
        {
            inputManager.OnMouseClick += structureManager.GeotermalPowerStationUnder;
        }
    }
    private void HydroElectricPanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(HydroElectricPrefab.prefab,HydroElectricPrefab.area);
        if (PlayerPrefs.GetInt("Money") - 800 >= 0)
        {
            inputManager.OnMouseClick += structureManager.HydroElectricPanel;
        }
    }
    private void Tree1PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Tree1Prefab.prefab, Tree1Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 10 >= 0)
        {
            inputManager.OnMouseClick += structureManager.Tree1;
        }
    }
    private void Tree2PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Tree2Prefab.prefab, Tree2Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 10 >= 0)
        {
            inputManager.OnMouseClick += structureManager.Tree2;
        }
    }
    private void Tree3PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Tree3Prefab.prefab, Tree3Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 10 >= 0)
        {
            inputManager.OnMouseClick += structureManager.Tree3;
        }
    }
    private void Tree4PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Tree4Prefab.prefab, Tree4Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 10 >= 0)
        {
            inputManager.OnMouseClick += structureManager.Tree4;
        }
    }
    private void Tree5PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Tree5Prefab.prefab, Tree5Prefab.area);
        if (PlayerPrefs.GetInt("Money") - 10 >= 0)
        {
            inputManager.OnMouseClick += structureManager.Tree5;
        }
    }
    private void FlatHouse1PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(FlatHouse1Prefab.prefab, FlatHouse1Prefab.area);
        inputManager.OnMouseClick += structureManager.FlatHouse1;
    }
    private void FlatHouse2PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(FlatHouse2Prefab.prefab, FlatHouse2Prefab.area);
        inputManager.OnMouseClick += structureManager.FlatHouse2;
    }
    private void House1PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(House1Prefab.prefab, House1Prefab.area);
        inputManager.OnMouseClick += structureManager.House1;
    }
    private void House2PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(House2Prefab.prefab, House2Prefab.area);
        inputManager.OnMouseClick += structureManager.House2;
    }
    private void House3PanelPlacement()
    {
        sentinel++;
        if (sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(House3Prefab.prefab, House3Prefab.area);
        inputManager.OnMouseClick += structureManager.House3;
    }
    private void Apartment2PanelPlacement()
    {
        sentinel++;
        if(sentinel > 1)
            previewSystem.StopShowingPreview();
        ClearInputActions();
        previewSystem.StartShowingPlacementPreview(Apartment2Prefab.prefab, Apartment2Prefab.area);
        inputManager.OnMouseClick += structureManager.Apartment2;
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
        UpdateTimerUI();

        if (box1.activeSelf == false && box2.activeSelf == false && box3.activeSelf == false)
            cancelB.SetActive(false);

        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("GoldEnergy.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("currency");

        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
            PlayerPrefs.SetInt("Money", int.Parse(mydoc2.SelectSingleNode("currency/gold").InnerText));

        cameraMovement.MoveCamera(
            new Vector3(
                inputManager.CameraMovementVector.x,
            0,
            inputManager.CameraMovementVector.y
            ));
    }
}
