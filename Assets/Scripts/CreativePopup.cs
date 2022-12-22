using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;

namespace geyikgames.unity.popup
{
    public class CreativePopup : Popup
    {
        public void Initialize()
        {
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

            if (action == 1)
            {
                //START A FRESH CREATIVE GAME HERE
                SceneManager.LoadScene("GameScene");
            }
            if (action == 2)
            {
                //LOAD CREATIVE GAME DATA HERE FROM XML
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
