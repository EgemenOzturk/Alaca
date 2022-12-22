using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;

namespace geyikgames.unity.popup
{
    public class CodexPopup : Popup
    {
        [SerializeField] private GameObject textRenewable;
        [SerializeField] private GameObject textNonRenewable;
        private int clickedAt;

        public void Initialize()
        {
            clickedAt = 0;
            textRenewable.SetActive(true);
            textNonRenewable.SetActive(false);
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
        }

        public override void Clicked(int action)
        {
            base.Clicked(action);

            Debug.Log("Click event. Action: " + action);

            if(action == 1 && clickedAt % 2 == 0)
            {
                textNonRenewable.SetActive(true);
                textRenewable.SetActive(false);
                clickedAt++;
            }
            else if (action == 1 && clickedAt % 2 == 1)
            {
                textNonRenewable.SetActive(false);
                textRenewable.SetActive(true);
                clickedAt++;
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
