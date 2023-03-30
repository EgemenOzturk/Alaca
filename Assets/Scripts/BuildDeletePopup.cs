using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class BuildDeletePopup : Popup
    {
        [SerializeField] public GameObject buildDesc;
        [SerializeField] public GameObject deleteDesc;
        [SerializeField] public GameObject buildTag;
        [SerializeField] public GameObject deleteTag;
        public int isBuilding;

        [SerializeField] public GameObject[] itemsBuildable;

        public void Initialize()
        {
        }

        public void setBuild(int a)
        {
            isBuilding = a;
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
                    buildDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/buildDesc").InnerText.Trim();
                    deleteDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/deleteDesc").InnerText.Trim();
                    buildTag.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/buildTag").InnerText.Trim();
                    deleteTag.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/deleteTag").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    buildDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/buildDesc").InnerText.Trim();
                    deleteDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/deleteDesc").InnerText.Trim();
                    buildTag.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/buildTag").InnerText.Trim();
                    deleteTag.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/deleteTag").InnerText.Trim();
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
