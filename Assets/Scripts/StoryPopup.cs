using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class StoryPopup : Popup
    {
        [SerializeField] public GameObject storyHead;
        [SerializeField] public GameObject storyDesc;
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
                    storyHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/storyHead").InnerText.Trim();
                    storyDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/storyDesc").InnerText.Trim();
                    newG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/newG").InnerText.Trim();
                    loadG.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/loadG").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    storyHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/storyHead").InnerText.Trim();
                    storyDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/storyDesc").InnerText.Trim();
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

            if(action == 1)
            {
                //START A FRESH STORY GAME HERE
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("BuildData.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("build");
                nodelist = nodelist[0].ChildNodes;

                if(nodelist.Count > 0)
                {
                    mydoc.SelectSingleNode("build/buildStats").InnerText = "";
                    mydoc.SelectSingleNode("build/buildNewTrue").InnerText = "True";
                    mydoc.Save("BuildData.xml");
                }

                SceneManager.LoadScene("GameScene");
            }
            if (action == 2)
            {
                //LOAD STORY GAME DATA HERE FROM XML
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("BuildData.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("build");
                nodelist = nodelist[0].ChildNodes;

                if(mydoc.SelectSingleNode("build/buildStats").InnerText.Trim().Length > 0)
                { 
                    if (nodelist.Count > 0)
                    {
                        mydoc.SelectSingleNode("build/buildNewTrue").InnerText = "False";
                        mydoc.Save("BuildData.xml");
                    }

                    SceneManager.LoadScene("GameScene");
                }
                else
                {
                    Debug.Log("ERROR, YOU CANNOT LOAD EMPTY GAME!");
                }
            }
        }
    }
}
