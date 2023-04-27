using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement,OnBigSturcturePlacement,OnDeleteObject;
	public Button placeRoadButton, placeHouseButton, placeSpecialButton,placeBigStructureButton,deleteObject;


	List<Button> buttonList;

	private void Start()
	{
		buttonList = new List<Button>() { placeHouseButton, placeSpecialButton, placeRoadButton, placeBigStructureButton };

		placeRoadButton.onClick.AddListener(() =>
		{
			OnRoadPlacement?.Invoke();
		});
		placeHouseButton.onClick.AddListener(() =>
		{
			OnHousePlacement?.Invoke();
		});
		placeSpecialButton.onClick.AddListener(() =>
		{
			OnSpecialPlacement?.Invoke();
		});
        placeBigStructureButton.onClick.AddListener(() =>
        {
            OnBigSturcturePlacement?.Invoke();
        });
        deleteObject.onClick.AddListener(() =>
        {
            OnDeleteObject?.Invoke();
        });
    }



	
}
