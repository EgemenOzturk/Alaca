using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace geyikgames.unity.popup
{
    public class ReturnPopup : Popup
    {
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
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
