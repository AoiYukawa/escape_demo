using System.Collections;
using System.Collections.Generic;
using Unity.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Assets.Scripts
{
	public class SceneLoader : MonoBehaviour
	{
		public Animator Transition;
		public string SceneName;
		public float TransitionTime = 1.0f;

		private bool _isLoaded = false;

		private void Start()
		{
		}

		void Update()
		{
			//if (!_isLoaded)
			//{
			//	LoadNextScene(SceneName);
			//}
		}

		public void LoadNextScene(string Scene)
		{
			StartCoroutine(LoadLevel(Scene));
		}

		IEnumerator LoadLevel(string Scene)
		{
			Transition.SetTrigger("Start");

			yield return new WaitForSeconds(TransitionTime);

			SceneManager.LoadScene(Scene);
			_isLoaded = true;
		}

		public bool IsLoaded
		{
			get => _isLoaded;
		}
	}
}
