using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geyikgames.unity.popup;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private Sprite testBackground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAchievements()
    {
        PopupController.Instance.Open<CodexPopup>("CodexPopup", (popup) =>
        {
            popup.Initialize(testBackground);
        });
    }
}
