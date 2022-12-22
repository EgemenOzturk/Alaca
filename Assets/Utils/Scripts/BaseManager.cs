using UnityEngine;
using UnityEngine.SceneManagement;
using geyikgames.unity.util;
using geyikgames.unity.popup;

namespace geyikgames.unity.manager
{
    [RequireComponent(typeof(DoNotDestroyOnLoad))]
    public abstract class BaseManager<T> : Singleton<T> where T : BaseManager<T>
    {
        protected virtual void Awake()
        {
            gameObject.GetComponent<DoNotDestroyOnLoad>().Id = "manager";
            _ = PopupController.Instance;

            Application.targetFrameRate = 60;
        }

        public virtual void LoadScene(string scene)
        {
            SceneManager.LoadSceneAsync(scene);
        }

    }
}
