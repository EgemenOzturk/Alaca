using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geyikgames.unity.popup;
using geyikgames.manager;

public class InGameUIController : MonoBehaviour
{
    private void Awake()
    {
        _ = Manager.Instance;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenReturn()
    {
        PopupController.Instance.Open<ReturnPopup>("ReturnPopup", (popup) =>
        {
            popup.Initialize();
        });
    }
}
