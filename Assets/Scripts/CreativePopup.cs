using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class CreativePopup : Popup
    {
        [SerializeField] public GameObject creativeHead;
        [SerializeField] public GameObject creativeDesc;
        [SerializeField] public GameObject newG;
        [SerializeField] public GameObject loadG;
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
                    creativeHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/creativeHead").InnerText.Trim();
                    creativeDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/creativeDesc").InnerText.Trim();
                    newG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/newG").InnerText.Trim();
                    loadG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/loadG").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    creativeHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/creativeHead").InnerText.Trim();
                    creativeDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/creativeDesc").InnerText.Trim();
                    newG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/newG").InnerText.Trim();
                    loadG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/loadG").InnerText.Trim();
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
                //START A FRESH CREATIVE GAME HERE
                SceneManager.LoadScene("TownScene");
            }
            if (action == 2)
            {
                //LOAD CREATIVE GAME DATA HERE FROM XML
                SceneManager.LoadScene("TownScene");
            }
        }
    }
}
