using UnityEngine;
using Debug = UnityEngine.Debug;
using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using TMPro;


namespace geyikgames.unity.popup
{
    public class AchievementsPopup : Popup
    {
        [SerializeField] public GameObject[] achievementDescs; 
        [SerializeField] public GameObject[] achievementNames; 
        [SerializeField] public GameObject achievementTitle; 
        private GameObject Achievements; // assign the prefab in the inspector
        public List<Achievement> AchievementList; // list to store the achievements

        public void Initialize()
        {
        }

        public override void Opening()
        {
            base.Opening();

            XmlDocument mydoc = new XmlDocument();
            mydoc.Load("AchievementData.xml");
            XmlNodeList nodelist = mydoc.SelectNodes("achievements");

            nodelist = nodelist[0].ChildNodes;


            XmlDocument mydoc2 = new XmlDocument();
            mydoc2.Load("Language.xml");

            if (nodelist.Count > 0)
            {
                if(mydoc2.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    achievementTitle.GetComponent<UnityEngine.UI.Text>().text = "Ba?ar?mlar";
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        XmlNode node = nodelist[i];
                        achievementDescs[i].GetComponent<UnityEngine.UI.Text>().text = node.Attributes["description2"].Value;
                        achievementNames[i].GetComponent<UnityEngine.UI.Text>().text = node.Attributes["name2"].Value;
                    }
                }
                else if(mydoc2.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    achievementTitle.GetComponent<UnityEngine.UI.Text>().text = "Achievements";
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        XmlNode node = nodelist[i];
                        achievementDescs[i].GetComponent<UnityEngine.UI.Text>().text = node.Attributes["description"].Value;
                        achievementNames[i].GetComponent<UnityEngine.UI.Text>().text = node.Attributes["name"].Value;
                    }
                }
            }
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
        }
    }

    // class to represent an achievement
    public class Achievement
    {
        public string name;
        public string description;
    }
}
