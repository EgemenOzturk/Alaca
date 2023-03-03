using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Xml;
using TMPro;

public class GoldEnergyTracker : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goldText; //sonra deðiþtir
    [SerializeField] public TextMeshProUGUI energyText; //sonra deðiþtir

    // Start is called before the first frame update
    void Start()
    {
        readGoldEnergy();
    }
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
            goldText.GetComponent<TMP_Text>().text = "Gold: " + mydoc.SelectSingleNode("currency/gold").InnerText;

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
            energyText.GetComponent<TMP_Text>().text = "Energy: " + mydoc.SelectSingleNode("currency/energy").InnerText;

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
        
        if (nodelist.Count > 0)
        {
            goldText.GetComponent<TMP_Text>().text = "Gold: " + mydoc.SelectSingleNode("currency/gold").InnerText;
            energyText.GetComponent<TMP_Text>().text = "Energy: " + mydoc.SelectSingleNode("currency/energy").InnerText;
        }
    }
}
