using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using static TreeEditor.TreeGroup;
using System.Xml;
using TMPro;

namespace geyikgames.unity.popup
{
    public class CodexPopup : Popup
    {
        [SerializeField] public GameObject[] renNames;
        [SerializeField] public GameObject[] nonRenNames;
        [SerializeField] public GameObject listRenewable;
        [SerializeField] public GameObject listNonRenewable;
        [SerializeField] public GameObject textRenewable;
        [SerializeField] public GameObject textNonRenewable;
        [SerializeField] public GameObject switchButton;
        [SerializeField] public GameObject codexHeader;

        private int clickedAt;

        public void Initialize()
        {
            clickedAt = 0;
            listRenewable.SetActive(true);
            listNonRenewable.SetActive(false);
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
                    textRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/textRenewable").InnerText.Trim();
                    textNonRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/textNonRenewable").InnerText.Trim();
                    switchButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/switchButton").InnerText.Trim();
                    codexHeader.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/codexHeader").InnerText.Trim();

                    for(int x = 1; x < 7; x++)
                    {
                        renNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/R" + "plantname" + x).InnerText.Trim();
                        nonRenNames[x - 1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/Turkish/NR" + "plantname" + x).InnerText.Trim();
                    }
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    textRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/textRenewable").InnerText.Trim();
                    textNonRenewable.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/textNonRenewable").InnerText.Trim();
                    switchButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/switchButton").InnerText.Trim();
                    codexHeader.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/codexHeader").InnerText.Trim();

                    for (int x = 1; x < 7; x++)
                    {
                        renNames[x-1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/R" + "plantname" + x).InnerText.Trim();
                        nonRenNames[x-1].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/English/NR" + "plantname" + x).InnerText.Trim();
                    }
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

            if (action == 1 && clickedAt % 2 == 0)
            {
                listNonRenewable.SetActive(true);
                listRenewable.SetActive(false);
                clickedAt++;
            }
            else if (action == 1 && clickedAt % 2 == 1)
            {
                listNonRenewable.SetActive(false);
                listRenewable.SetActive(true);
                clickedAt++;
            }

            if (action < 8 && action > 1)
            {
                PopupController.Instance.Open<OpenLorePopup>("OpenLore", (popup) =>
                {
                    popup.Initialize(action, true);
                });
            }
            else if (action < 14 && action > 7)
            {
                PopupController.Instance.Open<OpenLorePopup>("OpenLore", (popup) =>
                {
                    popup.Initialize(action - 6, false);
                });
            }
        }

        /*
        //[SerializeField] private Image backImage;
        //[SerializeField] private Text livesText;
        //[SerializeField] private Text headerText;


        private const string MENU_SCENE_NAME = "MenuScene";
        public void Initialize(Sprite backgroundImage, string remainingLives = "0", bool isSuccess = false)
        {
            Debug.Log("ExamplePopup Initialize");
            //backImage.sprite = backgroundImage;
            //headerText.color = Color.yellow;
            if (isSuccess)
            {
                //livesText.text = "PLAYER LIVES LEFT WHEN GAME OVER: " + remainingLives;
                //headerText.text = "SUCCESS";

            }
            else
            {
                //headerText.text = "FAIL";
                //livesText.text = "";
            }
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
            SceneManager.LoadScene(MENU_SCENE_NAME);
        }

        public override void Clicked(int action)
        {
            base.Clicked(action);

            Debug.Log("Click event. Action: " + action);
        }*/


    }
}
