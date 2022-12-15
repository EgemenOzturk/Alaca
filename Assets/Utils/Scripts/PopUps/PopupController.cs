using System;
using System.Collections;
using System.Collections.Generic;
using geyikgames.unity.util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace geyikgames.unity.popup
{
	[RequireComponent(typeof(DoNotDestroyOnLoad))]
	public class PopupController : Singleton<PopupController>
	{
		private Dictionary<string, GameObject> popups = new Dictionary<string, GameObject>();
		private List<string> openedPopups = new List<string>();
		private string activePopup = null;
		private Transform popupLayer;

		private void Awake()
		{
			gameObject.GetComponent<DoNotDestroyOnLoad>().Id = "popup_controller";
			Init();
			SceneManager.sceneLoaded += SceneChange;
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			SceneManager.sceneLoaded -= SceneChange;
		}

		private void SceneChange(Scene arg0, LoadSceneMode arg1)
		{
			popupLayer = GameObject.FindGameObjectWithTag("PopupLayer").transform;
			activePopup = null;
			openedPopups = new List<string>();
			popups = new Dictionary<string, GameObject>();
		}

		public void Init()
		{
			if (popupLayer == null)
			{
				popupLayer = GameObject.FindGameObjectWithTag("PopupLayer").transform;
				CloseAll();
			}
		}

		public void Open<T>(string type, Action<T> opening = null) where T : Popup
		{
			CloseAll();
			OpenTop(type, opening);
		}

		public void OpenTop<T>(string type, Action<T> opening = null) where T : Popup
		{
			if (openedPopups.IndexOf(type) != -1)
			{
				openedPopups.Remove(type);
			}

			openedPopups.Add(type);

			if (!popups.ContainsKey(type) || popups[type] == null)
			{
				GameObject go = Resources.Load<GameObject>("Popups/" + type);

				if (go != null)
				{
					popups[type] = UnityEngine.Object.Instantiate(go, popupLayer);
				}
			}

			T tmp = popups[type].GetComponent<T>();
			tmp.Opening();
			opening?.Invoke(tmp);
			tmp.gameObject.SetActive(true);
			tmp.Opened();
			tmp.transform.SetAsLastSibling();
			popups[type] = tmp.gameObject;
			activePopup = type;
		}

		public bool Close()
		{
			if (activePopup == null) return false;

			try
			{
				popups[activePopup].GetComponent<Popup>().Closing();
				popups[activePopup].GetComponent<Popup>().Close();
			}
			catch (System.Exception ex)
			{
				Debug.LogWarning("Close Error : " + ex);

				try
				{
					popups[activePopup].SetActive(false);
				}
				catch (System.Exception exp)
				{
					Debug.LogWarning("Close Error : " + exp.Message);
					popups[activePopup] = null;
				}
			}

			openedPopups.RemoveAt(openedPopups.Count - 1);

			activePopup = openedPopups.Count == 0 ? null : openedPopups[openedPopups.Count - 1];

			return true;
		}

		public void Reload(string type)
		{
			try
			{
				popups[type].GetComponent<Popup>().Reload();
			}
			catch (Exception e)
			{
				Debug.LogWarning("Reload Error: " + e.ToString());
			}
		}

		public Popup GetPopup(string type)
		{
			try
			{
				return popups[type].GetComponent<Popup>();
			}
			catch (Exception e)
			{
				Debug.LogWarning("GetPopup Error: " + e.ToString());
			}

			return null;
		}

		public void CloseAll()
		{
			while (Close()) { }
		}

		public bool IsOpen(string type)
		{
			return activePopup == type;
		}

		public bool IsPopupActive()
		{
			return activePopup != null;
		}

		public void ProcessInterrnalMessage(string type, string action, ArrayList parameters = null)
		{

			if (type == null || type.Length == 0)
			{
				return;
			}

			if (popups.ContainsKey(type))
			{
				try
				{
					popups[type].GetComponent<Popup>().ProcessInternalMessage(action, parameters);
				}
				catch (Exception e)
				{
					Debug.LogWarning("ProcessMessage Error: " + e.ToString());
				}
			}
			else if (GameObject.FindGameObjectWithTag(type) != null)
			{
				try
				{
					GameObject.FindGameObjectWithTag(type).GetComponent<Popup>().ProcessInternalMessage(action, parameters);
				}
				catch (Exception e)
				{
					Debug.LogWarning("ProcessInternalMessage Error: " + e.ToString());
				}
			}
		}

		public void ProcessMessage(string action, ArrayList parameters = null)
		{
			for (int i = 0; i < openedPopups.Count; i++)
			{
				try
				{
					popups[openedPopups[i]].GetComponent<Popup>().ProcessInternalMessage(action, parameters);
				}
				catch (Exception e)
				{
					Debug.LogWarning("ProcessInternalMessage Error: " + e.ToString());
				}
			}
		}
	}
}