using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using static TreeEditor.TreeGroup;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class TestEventPopup : Popup
    {
        [SerializeField] public GameObject eventHead;
        [SerializeField] public GameObject eventDesc;
        [SerializeField] public GameObject eventOpt1;
        [SerializeField] public GameObject eventOpt2;

        public void Initialize()
        {
        }

        void Update()
        {

        }

        public override void Opening()
        {
            base.Opening();
            Debug.Log("Called before setActive(true)");

            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("Language.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("Language");
            nodelist = nodelist[0].ChildNodes;

            if (nodelist.Count > 0)
            {
                if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    eventHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventHead").InnerText.Trim();
                    eventDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventDesc").InnerText.Trim();
                    eventOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventOpt1").InnerText.Trim();
                    eventOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventOpt2").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    eventHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventHead").InnerText.Trim();
                    eventDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventDesc").InnerText.Trim();
                    eventOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventOpt1").InnerText.Trim();
                    eventOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventOpt2").InnerText.Trim();
                }
            }
        }

        public override void Opened()
        {
            base.Opened();
            Debug.Log("Called after setActive(true)");
        }

        public override void Closing()
        {
            base.Closing();
            Debug.Log("Called before setActive(false)");
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("Called to close");
        }

        public override void Closed()
        {
            base.Closed();
        }

        public override void Clicked(int action)
        {
            base.Clicked(action);

            Debug.Log("Click event. Action: " + action);

            if(action == 1)
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("GoldEnergy.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("currency");

                nodelist = nodelist[0].ChildNodes;

                if (nodelist.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) > 0)
                {
                    mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) + 50).ToString();
                    mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) - 100).ToString();
                    mydoc.Save("GoldEnergy.xml");
                    Clicked(0);
                }
                else
                {
                    Debug.Log("Error! There is not enough Gold!");
                }
            }

            if(action == 2)
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("GoldEnergy.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("currency");

                nodelist = nodelist[0].ChildNodes;

                if (nodelist.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) > 0)
                {
                    mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) - 10).ToString();
                    mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) + 20).ToString();
                    mydoc.Save("GoldEnergy.xml");
                    Clicked(0);
                }
                else
                {
                    Debug.Log("Error! There is not enough Energy!");
                }
            }

        }
    }
}
