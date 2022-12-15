using UnityEngine;

// TODO script execution order
namespace geyikgames.unity.util
{
	public class DoNotDestroyOnLoad : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField] private string id;
#pragma warning restore 0649

		void Awake()
		{
			DoNotDestroyOnLoad[] objs = FindObjectsOfType<DoNotDestroyOnLoad>();

			for (int i = 0; i < objs.Length; i++)
			{
				if (objs[i].Id == this.id && gameObject != objs[i].gameObject)
				{
					Destroy(gameObject);
					return;
				}
			}

			DontDestroyOnLoad(gameObject);
		}

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
	}
}

