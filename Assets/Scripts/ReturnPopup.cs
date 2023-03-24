using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using static TreeEditor.TreeGroup;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class ReturnPopup : Popup
    {
        [SerializeField] public GameObject returnDesc;
        [SerializeField] public GameObject returnHead;
        [SerializeField] public GameObject returnYes;
        [SerializeField] public GameObject returnNo;
        [SerializeField] public GridManager theGrid;

        public void Initialize()
        {
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Check if the mouse was clicked over a UI element
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Clicked on the UI");
                }
            }
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
                    returnDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/returnDesc").InnerText.Trim();
                    returnHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/returnHead").InnerText.Trim();
                    returnYes.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/returnYes").InnerText.Trim();
                    returnNo.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/returnNo").InnerText.Trim();
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    returnDesc.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/returnDesc").InnerText.Trim();
                    returnHead.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/returnHead").InnerText.Trim();
                    returnYes.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/returnYes").InnerText.Trim();
                    returnNo.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/returnNo").InnerText.Trim();
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

            if(action == 2)
            {
                //SAVE THE GAME'S DATA HERE, READ THE XML VALUE TAKEN FROM THE FILE
                //TO DETERMINE WHETHER THE GAME IS IN STORY OR CREATIVE MODE

                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("BuildData.xml");
                XmlNodeList nodelist = mydoc.SelectNodes("build");
                nodelist = nodelist[0].ChildNodes;

                if (nodelist.Count > 0)
                {
                    mydoc.SelectSingleNode("build/buildNewTrue").InnerText = "False";

                    /* I have abandoned this idea in favor of loading data to XML exactly immediately AFTER an item is constructed on the grid
                     **** BURADA (HE*HEIGHT) + WIDTH ILE LINEER ARRAYA KOYABÝLÝRSÝN BUNU UNUTMA ****

                    for (int i = 0; i < mydoc.SelectSingleNode("build/buildStats").InnerText.Trim().Length; i++)
                    {
                        mydoc.SelectSingleNode("build/buildStats").InnerText += theGrid.infoLoad[i];
                    }
                    */

                    mydoc.Save("BuildData.xml");
                }

                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
