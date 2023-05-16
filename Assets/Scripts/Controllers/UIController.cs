using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Action OnRoadPlacement,OnDeleteObject,OnWindmillPlacement,OnSolarPanelPlacement,OnSmall_power_plant_2x2_Placement, 
        OnNuclearPowerPlantPlacement, OnNuclearPowerPlant2Placement,OnPottedPowerPlantPlacement, OnCoalPowerPlantButton, OnGeotermalPowerPlantPrefab,
        OnGeotermalPowerPlantUnderPrefab,OnWawePanel, OnHydroelectricPanel,OnRenewablePanel,OnTree1Panel,OnTree2Panel, OnTree3Panel, OnTree4Panel,
        OnTree5Panel,OnFlatHouse1Panel,OnFlatHouse2Panel, OnHouse1Panel, OnHouse2Panel, OnHouse3Panel, OnApartment2Panel;
	public Button placeRoadButton,deleteObject,placeWindmillButton, placeSolarPanelButton, placeSmall_power_plant_2x2Button,
        placeNuclearPowerPlantButton, placeNuclearPowerPlant2Button, placePottedPowerPlantButton, placeCoalPowerPlantButton, placeGeotermalPowerPlantPrefab, 
        placeGeotermalPowerPlantUnderPrefab,placeWaweButton,placeHydroelectricButton,placeTree1Button, placeTree2Button, placeTree3Button, placeTree4Button, placeTree5Button,
        placeFlatHouse1Button, placeFlatHouse2Button,placeHouse1Button, placeHouse2Button, placeHouse3Button
        , placeApartment2Button;

    public Button StoreButton, UnrenewableButton, RenewableButton,PropsButton,HousesButton;

    public GameObject mainPanel,StorePanel, UnrenewablePanel, RenewablePanel, PropsPanel, HousesPanel;
	private void Start()
	{
        
        placeRoadButton.onClick.AddListener(() =>
        {
            OnRoadPlacement?.Invoke();
        });
        placeWindmillButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnWindmillPlacement?.Invoke();
        });
        placeSolarPanelButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnSolarPanelPlacement?.Invoke();
        });
        placeSmall_power_plant_2x2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnSmall_power_plant_2x2_Placement?.Invoke();
        });
        placeNuclearPowerPlantButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnNuclearPowerPlantPlacement?.Invoke();
        });
        placeNuclearPowerPlant2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnNuclearPowerPlant2Placement?.Invoke();
        });
        placePottedPowerPlantButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnPottedPowerPlantPlacement?.Invoke();
        });
        placeCoalPowerPlantButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnCoalPowerPlantButton?.Invoke();
        });
        placeGeotermalPowerPlantPrefab.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnGeotermalPowerPlantPrefab?.Invoke();
        });
        placeGeotermalPowerPlantUnderPrefab.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnGeotermalPowerPlantUnderPrefab?.Invoke();
        });
        placeWaweButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnWawePanel?.Invoke();
        });
        placeHydroelectricButton.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnHydroelectricPanel?.Invoke();
        });
        placeTree1Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnTree1Panel?.Invoke();
        });
        placeTree2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnTree2Panel?.Invoke();
        });
        placeTree3Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnTree3Panel?.Invoke();
        });
        placeTree4Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnTree4Panel?.Invoke();
        });
        placeTree5Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnTree5Panel?.Invoke();
        });

        placeFlatHouse1Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnFlatHouse1Panel?.Invoke();
        });
        placeFlatHouse2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnFlatHouse2Panel?.Invoke();
        });
        placeHouse1Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnHouse1Panel?.Invoke();
        });
        placeHouse2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnHouse2Panel?.Invoke();
        });
        placeHouse3Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnHouse3Panel?.Invoke();
        });
        placeApartment2Button.onClick.AddListener(() =>
        {
            mainPanel.SetActive(true);
            StorePanel.SetActive(false);
            RenewablePanel.SetActive(false);
            UnrenewablePanel.SetActive(false);
            PropsPanel.SetActive(false);
            HousesPanel.SetActive(false);
            OnApartment2Panel?.Invoke();
        });
        deleteObject.onClick.AddListener(() =>
        {
            OnDeleteObject?.Invoke();
        });
    }

    public void StoreClick()
    {
        StorePanel.SetActive(true);
        mainPanel.SetActive(false);
        RenewablePanel.SetActive(false);
        UnrenewablePanel.SetActive(false);
        PropsPanel.SetActive(false);
        HousesPanel.SetActive(false);
    }

    public void UnrenewableClick()
    {
        StorePanel.SetActive(false);
        mainPanel.SetActive(false);
        RenewablePanel.SetActive(false);
        UnrenewablePanel.SetActive(true);
        PropsPanel.SetActive(false);
        HousesPanel.SetActive(false);
    }
    public void RenewableClick()
    {
        StorePanel.SetActive(false);
        mainPanel.SetActive(false);
        RenewablePanel.SetActive(true);
        UnrenewablePanel.SetActive(false);
        PropsPanel.SetActive(false);
        HousesPanel.SetActive(false);
    }
    public void PropsClick()
    {
        StorePanel.SetActive(false);
        mainPanel.SetActive(false);
        RenewablePanel.SetActive(false);
        UnrenewablePanel.SetActive(false);
        PropsPanel.SetActive(true);
        HousesPanel.SetActive(false);
    }
    public void HousesClick()
    {
        StorePanel.SetActive(false);
        mainPanel.SetActive(false);
        RenewablePanel.SetActive(false);
        UnrenewablePanel.SetActive(false);
        PropsPanel.SetActive(false);
        HousesPanel.SetActive(true);
    }
}
