using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Xml;
using TMPro;

public class GoldEnergyTracker : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goldText; //sonra de�i�tir
    [SerializeField] public TextMeshProUGUI energyText; //sonra de�i�tir

    // Start is called before the first frame update
    void Start()
    {
        readGoldEnergy();
    }

    public void changeGold(int amount)
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) + amount).ToString();
            goldText.GetComponent<TMP_Text>().text = "Gold: " + mydoc.SelectSingleNode("currency/gold").InnerText;

            mydoc.Save("GoldEnergy.xml");
        }
    }

    public void changeEnergy(int amount)
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) + amount).ToString();
            energyText.GetComponent<TMP_Text>().text = "Energy: " + mydoc.SelectSingleNode("currency/energy").InnerText;

            mydoc.Save("GoldEnergy.xml");
        }
    }

    private void readGoldEnergy() 
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;
        
        Debug.Log(nodelist.Count);

        if (nodelist.Count > 0)
        {
            goldText.GetComponent<TMP_Text>().text = "Gold: " + mydoc.SelectSingleNode("currency/gold").InnerText;
            energyText.GetComponent<TMP_Text>().text = "Energy: " + mydoc.SelectSingleNode("currency/energy").InnerText;
        }
    }
}
