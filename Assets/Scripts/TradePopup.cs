using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class TradePopup : Popup
    {
        [SerializeField] public GameObject tradeHead;
        [SerializeField] public GameObject tradeDesc;
        [SerializeField] public GameObject tradeOpt1;
        [SerializeField] public GameObject tradeOpt2;
        [SerializeField] public GameObject tradeOpt3;
        [SerializeField] public GameObject tradeOpt4;
        public void Initialize()
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
                    tradeHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeHead").InnerText.Trim();
                    tradeDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeDesc").InnerText.Trim();
                    tradeOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeOpt1").InnerText.Trim();
                    tradeOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeOpt2").InnerText.Trim();
                    tradeOpt3.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeOpt3").InnerText.Trim();
                    tradeOpt4.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/tradeOpt4").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    tradeHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeHead").InnerText.Trim();
                    tradeDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeDesc").InnerText.Trim();
                    tradeOpt1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeOpt1").InnerText.Trim();
                    tradeOpt2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeOpt2").InnerText.Trim();
                    tradeOpt3.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeOpt3").InnerText.Trim();
                    tradeOpt4.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/tradeOpt4").InnerText.Trim();
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

            if (action == 1)
            {

            }
            if (action == 2)
            {

            }
        }
    }
}
