using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Xml;
using TMPro;

public class GoldEnergyTracker : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goldText; //sonra deðiþtir
    [SerializeField] public TextMeshProUGUI energyText; //sonra deðiþtir

    void Update()
    {
        readGoldEnergy();
    }

    public void changeGold(int amount)
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) > 0)
        {
            mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) + amount).ToString();
            mydoc.Save("GoldEnergy.xml");
        }
        else
        {
            Debug.Log("Error! There is not enough Gold!");
        }
    }

    public void changeEnergy(int amount)
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) > 0)
        {
            mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) + amount).ToString();
            mydoc.Save("GoldEnergy.xml");
        }
        else
        {
            Debug.Log("Error! There is not enough Energy!");
        }
    }

    private void readGoldEnergy() 
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("currency");

        nodelist = nodelist[0].ChildNodes;

        string energyStr = "";
        string goldStr = "";

        XmlDocument mydoc2 = new XmlDocument();
        mydoc2.Load("Language.xml");
        XmlNodeList nodelist2 = mydoc2.SelectNodes("Language");
        nodelist2 = nodelist2[0].ChildNodes;

        if (nodelist2.Count > 0)
        {
            if (mydoc2.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                energyStr = "Enerji";
                goldStr = "Altýn";
            }
            else if (mydoc2.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                energyStr = "Energy";
                goldStr = "Gold";
            }
        }

        if (nodelist.Count > 0)
        {
            goldText.GetComponent<TMP_Text>().text = goldStr + ": " + mydoc.SelectSingleNode("currency/gold").InnerText;
            energyText.GetComponent<TMP_Text>().text = energyStr + ": " + mydoc.SelectSingleNode("currency/energy").InnerText;
        }
    }
}
