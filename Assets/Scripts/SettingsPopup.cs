using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms;

namespace geyikgames.unity.popup
{
    public class SettingsPopup : Popup
    {
        [SerializeField] public GameObject turBut;
        [SerializeField] public GameObject enBut;

        [SerializeField] public GameObject lngText;
        [SerializeField] public GameObject lngText2;
        [SerializeField] public GameObject musOnText;
        [SerializeField] public GameObject musOffText;
        [SerializeField] public GameObject soundEffOnText;
        [SerializeField] public GameObject soundEffOffText;
        [SerializeField] public GameObject settingsHead;
        [SerializeField] public GameObject settingsDesc;

        private string langText;

        public void Initialize()
        {
        }

        public override void Opening()
        {
            base.Opening();
            Debug.Log("Called before setActive(true)");

            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("Language.xml");

            if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                langText = "Turkish";
                turBut.SetActive(true);
                enBut.SetActive(false);
            }
            else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
            {
                langText = "English";
                turBut.SetActive(false);
                enBut.SetActive(true);
            }

            settingsHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
            settingsDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settingsDesc").InnerText.Trim();
            lngText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
            lngText2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
            musOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOnText").InnerText.Trim();
            musOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOffText").InnerText.Trim();
            soundEffOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOnText").InnerText.Trim();
            soundEffOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOffText").InnerText.Trim();
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
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("Language.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("Language");
                nodelist = nodelist[0].ChildNodes;

                if (nodelist.Count > 0)
                {
                    mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "False";
                    mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "True";

                    langText = "Turkish";
                    turBut.SetActive(true);
                    enBut.SetActive(false);

                    settingsHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
                    settingsDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settingsDesc").InnerText.Trim();
                    lngText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
                    lngText2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
                    musOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOnText").InnerText.Trim();
                    musOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOffText").InnerText.Trim();
                    soundEffOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOnText").InnerText.Trim();
                    soundEffOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOffText").InnerText.Trim();

                    mydoc.Save("Language.xml");
                }
            }
            if (action == 2)
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("Language.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("Language");
                nodelist = nodelist[0].ChildNodes;

                if (nodelist.Count > 0)
                {
                    mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "False";
                    mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "True";
                    turBut.SetActive(false);
                    enBut.SetActive(true);

                    langText = "English";

                    settingsHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
                    settingsDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settingsDesc").InnerText.Trim();
                    lngText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
                    lngText2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
                    musOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOnText").InnerText.Trim();
                    musOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/musOffText").InnerText.Trim();
                    soundEffOnText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOnText").InnerText.Trim();
                    soundEffOffText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/soundEffOffText").InnerText.Trim();

                    mydoc.Save("Language.xml");
                }
            }
        }
    }
}
