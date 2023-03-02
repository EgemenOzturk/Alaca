using UnityEngine;
using Debug = UnityEngine.Debug;
using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GoldEnergyTracker : MonoBehaviour
{
    [SerializeField] public GameObject goldText; //sonra deðiþtir
    [SerializeField] public GameObject energyText; //sonra deðiþtir

    // Start is called before the first frame update
    void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("GoldEnergy.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("achievements");

        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            XmlNode node = nodelist[0];
            goldText.GetComponent<TMP_Text>().text = node.Attributes["gold"].Value;
            energyText.GetComponent<TMP_Text>().text = node.Attributes["energy"].Value;
        }

        /*XmlNode gold = mydoc.SelectSingleNode("gold");
        XmlNode energy = mydoc.SelectSingleNode("energy");

        goldText.GetComponent<UnityEngine.UI.Text>().text = gold.Attributes["amount"].Value;
        energyText.GetComponent<UnityEngine.UI.Text>().text = energy.Attributes["amount"].Value;*/

    }

    // Update is called once per frame
    void Update()
    {
    }
}
