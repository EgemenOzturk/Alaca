using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static MoneyController Instance { get; private set; }
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI pollutionText;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        moneyText.text = "Money : " + PlayerPrefs.GetInt("Money");
        pollutionText.text = "Pollution : " + PlayerPrefs.GetInt("Pollution");
    }
    public void setMoney(int money)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + money);
        moneyText.text = "Money : " + PlayerPrefs.GetInt("Money");
    }

    public void setPollution(int pollution)
    {
        PlayerPrefs.SetInt("Pollution", PlayerPrefs.GetInt("Pollution") + pollution);
        pollutionText.text = "Pollution : " + PlayerPrefs.GetInt("Pollution");
        FogController.Instance.ChangeFogDensity();
    }
}
