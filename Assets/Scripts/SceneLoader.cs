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

		public PlayerHealthManager _playerHealthMgr = null;
		private bool _isLoaded = false;

		void Update()
		{
			if (_playerHealthMgr.IsDead && !_isLoaded)
			{
				LoadNextScene(SceneName);
				_isLoaded = true;
			}
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
		}
	}
}
