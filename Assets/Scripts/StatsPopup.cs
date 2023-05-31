using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms;
using Unity.VisualScripting;

namespace geyikgames.unity.popup
{
    public class StatsPopup : Popup
    {
        [SerializeField] public GameObject Water;
        [SerializeField] public GameObject Air;
        [SerializeField] public GameObject Soil;
        [SerializeField] public GameObject Happiness;
        [SerializeField] public GameObject Immigration;
        [SerializeField] public GameObject LifeExpectancy;
        [SerializeField] public GameObject header;

        private string langText;

        public void Initialize()
        {
        }

        public void kill()
        {
            Destroy(this);
        }

        public override void Opening()
        {
            base.Opening();
            Debug.Log("Called before setActive(true)");

            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("Language.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("Language");
            nodelist = nodelist[0].ChildNodes;

            XmlDocument mydoc2 = new XmlDocument();
            mydoc2.Load("BuildData.xml");
            XmlNodeList nodelist2 = mydoc2.SelectNodes("build");
            nodelist2 = nodelist2[0].ChildNodes;

            if (nodelist.Count > 0 && nodelist2.Count > 0)
            {
                if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    Water.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/Water").InnerText.Trim();
                    Air.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/Air").InnerText.Trim();
                    Soil.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/Soil").InnerText.Trim();
                    Happiness.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/Happiness").InnerText.Trim();
                    Immigration.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/ImmigrationPull").InnerText.Trim();
                    LifeExpectancy.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/LifeExpectancy").InnerText.Trim();
                    header.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/cityStatHeader").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    Water.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/Water").InnerText.Trim();
                    Air.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/Air").InnerText.Trim();
                    Soil.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/Soil").InnerText.Trim();
                    Happiness.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/Happiness").InnerText.Trim();
                    Immigration.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/ImmigrationPull").InnerText.Trim();
                    LifeExpectancy.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/LifeExpectancy").InnerText.Trim();
                    header.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/cityStatHeader").InnerText.Trim();
                }

                Water.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/Water").InnerText.Trim();
                Air.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/Air").InnerText.Trim();
                Soil.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/Soil").InnerText.Trim();
                Happiness.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/Happiness").InnerText.Trim();
                Immigration.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/ImmigrationPull").InnerText.Trim();
                LifeExpectancy.GetComponent<TMP_Text>().text += " " + mydoc2.SelectSingleNode("build/LifeExpectancy").InnerText.Trim();
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

           
        }
    }
}
