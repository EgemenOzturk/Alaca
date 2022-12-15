using UnityEngine;

using geyikgames.unity.popup;
using UnityEngine.SceneManagement;

namespace geyikgames.unity.popup
{
    public class CodexPopup : Popup
    {
        [SerializeField] private Transform content;

        public void Initialize(Sprite backgroundImage)
        {
            ((RectTransform)content).anchoredPosition = new Vector2(0, 0);
        }

        public override void Clicked(int action)
        {
            base.Clicked(action);
        }
    }
}
