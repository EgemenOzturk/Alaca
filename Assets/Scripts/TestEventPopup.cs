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
        private int eventID;

        public void Initialize(int a)
        {
            eventID = a;
            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("Language.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("Language");
            nodelist = nodelist[0].ChildNodes;

            if (nodelist.Count > 0)
            {
                if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    eventHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventHead" + eventID.ToString()).InnerText.Trim();
                    eventDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventDesc" + eventID.ToString()).InnerText.Trim();
                    eventOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventOpt1" + eventID.ToString()).InnerText.Trim();
                    eventOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/eventOpt2" + eventID.ToString()).InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    eventHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventHead" + eventID.ToString()).InnerText.Trim();
                    eventDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventDesc" + eventID.ToString()).InnerText.Trim();
                    eventOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventOpt1" + eventID.ToString()).InnerText.Trim();
                    eventOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/eventOpt2" + eventID.ToString()).InnerText.Trim();
                }
            }
        }

        void Update()
        {

        }

        public override void Opening()
        {
            base.Opening();
            Debug.Log("Called before setActive(true)");
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

                XmlDocument mydoc2 = new XmlDocument();
                mydoc2.Load("EventData.xml");
                XmlNodeList nodelist2 = mydoc2.SelectNodes("event");

                nodelist = nodelist[0].ChildNodes;
                nodelist2 = nodelist2[0].ChildNodes;

                if (nodelist.Count > 0 && nodelist2.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) > 0)
                {
                    int goldToAdd = int.Parse(mydoc2.SelectSingleNode("event/event" + eventID + "ResG").InnerText);

                    int engToAdd = int.Parse(mydoc2.SelectSingleNode("event/event" + eventID + "ResE").InnerText);

                    Debug.Log(engToAdd);
                    Debug.Log(goldToAdd);

                    mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) + engToAdd).ToString(); //50
                    mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) + goldToAdd).ToString(); // -100
                    mydoc.Save("GoldEnergy.xml");
                    Clicked(0);
                }
                else
                {
                    Debug.Log("Error! There is not enough Gold/Energy!");
                }
            }

            if(action == 2)
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("GoldEnergy.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("currency");

                XmlDocument mydoc2 = new XmlDocument();
                mydoc2.Load("EventData.xml");
                XmlNodeList nodelist2 = mydoc2.SelectNodes("event");

                nodelist = nodelist[0].ChildNodes;
                nodelist2 = nodelist2[0].ChildNodes;

                if (nodelist.Count > 0 && nodelist2.Count > 0 && int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) > 0)
                {
                    int goldToAdd = int.Parse(mydoc2.SelectSingleNode("event/event" + eventID + "O2ResG").InnerText);

                    int engToAdd = int.Parse(mydoc2.SelectSingleNode("event/event" + eventID + "O2ResE").InnerText);

                    Debug.Log(engToAdd);
                    Debug.Log(goldToAdd);

                    mydoc.SelectSingleNode("currency/energy").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/energy").InnerText) + engToAdd).ToString(); //-10
                    mydoc.SelectSingleNode("currency/gold").InnerText = (int.Parse(mydoc.SelectSingleNode("currency/gold").InnerText) + goldToAdd).ToString(); //20
                    mydoc.Save("GoldEnergy.xml");
                    Clicked(0);
                }
                else
                {
                    Debug.Log("Error! There is not enough Gold/Energy!");
                }
            }

        }
    }
}
