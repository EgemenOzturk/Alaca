using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geyikgames.unity.popup;
using geyikgames.manager;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private Sprite testBackground;
    [SerializeField] private GameObject can;

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

    public void OpenCodex()
    {
        PopupController.Instance.Open<CodexPopup>("CodexPopup", (popup) =>
        {
            popup.Initialize();
        });
    }
}
