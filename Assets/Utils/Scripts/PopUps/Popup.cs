using System.Collections;
using UnityEngine;

namespace geyikgames.unity.popup
{
	public abstract class Popup : MonoBehaviour
	{
		public virtual void Opening() { }
		public virtual void Closing() { }

		public virtual void Opened()
		{
			if (GetComponent<Animator>() != null)
			{
				try
				{
					GetComponent<Animator>().Play("Open");
				}
				catch (System.Exception ex)
				{
					Debug.Log("Popup.Close() Exception : " + ex.Message);
				}
			}
		}
		public virtual void Reload() { }

		public virtual void Close()
		{
			if (GetComponent<Animator>() != null)
			{
				try
				{
					GetComponent<Animator>().Play("Close");
					StartCoroutine(Wait());

					IEnumerator Wait()
					{
						yield return new WaitForFixedUpdate();
						yield return new WaitUntil(() => GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Closed"));
						gameObject.SetActive(false);
						Closed();
					}
				}
				catch (System.Exception ex)
				{
					Debug.Log("Popup.Close() Exception : " + ex.Message);
					gameObject.SetActive(false);
					Closed();
				}
			}
			else
			{
				gameObject.SetActive(false);
				Closed();
			}
		}

		public virtual void ProcessInternalMessage(string action, ArrayList parameters = null) { }


		/// <summary>
		/// Button actions
		/// </summary>
		/// <param name="action">action 0 is close popup</param>
		public virtual void Clicked(int action)
		{
			if (action == 0)
			{
				PopupController.Instance.Close();
			}
		}

		public virtual void Closed()
		{

		}
	}
}

