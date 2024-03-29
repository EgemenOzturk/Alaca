using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geyikgames.unity.popup;
using geyikgames.manager;

public class InGameUIController : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 diff;
    private Vector3 resetCam;

    private bool drag = false;
    [SerializeField] public int testEventID;


    private void Awake()
    {
        _ = Manager.Instance;
    }

    void Start()
    {
        resetCam = Camera.main.transform.position;

        FireEvent(testEventID);
    }

    public void FireEvent(int a)
    {
        PopupController.Instance.Open<TestEventPopup>("TestEventPopup", (popup) =>
        {
            popup.Initialize(a);
        });
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            diff = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;

            if(drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if(drag)
        {
            Camera.main.transform.position = origin - diff;
        }

        if(Input.GetMouseButton(1))
        {
            Camera.main.transform.position = resetCam;
        }
    }

    public void OpenReturn()
    {
        PopupController.Instance.Open<ReturnPopup>("ReturnPopup", (popup) =>
        {
            popup.Initialize();
        });
    }

    public void OpenTrade()
    {
        PopupController.Instance.Open<TradePopup>("TradePopup", (popup) =>
        {
            popup.Initialize();
        });
    }

    public void OpenSettings()
    {
        PopupController.Instance.Open<SettingsPopup>("SettingsPopup", (popup) =>
        {
            popup.Initialize();
        });
    }


    public void OpenBuildDelete()
    {
        PopupController.Instance.Open<BuildDeletePopup>("BuildDeletePopup", (popup) =>
        {
            popup.Initialize();
        });
    }

    public void OpenStats()
    {
        PopupController.Instance.Open<StatsPopup>("StatsPopup", (popup) =>
        {
            popup.Initialize();
        });
    }
}
