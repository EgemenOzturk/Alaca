using UnityEngine;
using Debug = UnityEngine.Debug;
using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

namespace geyikgames.unity.popup
{
    public class OpenLorePopup : Popup
    {
        [SerializeField] public GameObject loreDesc;
        [SerializeField] public GameObject loreName;
        public int loreId;
        public string isRenewable;

        public void Initialize(int i, bool renewable)
        {
            loreId = i - 1;
            if(renewable)
            {
                isRenewable = "R";
            }
            else
            {
                isRenewable = "NR";
            }

            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("Language.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("Language");
            nodelist = nodelist[0].ChildNodes;

            if (nodelist.Count > 0)
            {
                if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    Debug.Log("Language/Turkish/" + isRenewable + "plantname" + loreId);
                    loreName.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/" + isRenewable + "plantname" + loreId).InnerText.Trim();
                    loreDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/" + isRenewable + "plantdesc" + loreId).InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    loreName.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/" + isRenewable + "plantname" + loreId).InnerText.Trim();
                    loreDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/" + isRenewable + "plantdesc" + loreId).InnerText.Trim();
                }
            }
        }

        public override void Opening()
        {
            base.Opening();
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
        }
    }
}
