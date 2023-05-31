using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
    private void Update()
    {
        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("GoldEnergy.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("currency");

        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
            PlayerPrefs.SetInt("Money", int.Parse(mydoc2.SelectSingleNode("currency/gold").InnerText));

        moneyText.text = "Money : " + PlayerPrefs.GetInt("Money");
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
