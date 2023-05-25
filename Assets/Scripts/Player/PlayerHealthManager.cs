using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Assets.Scripts.Scene;

namespace Unity.Assets.Scripts.Player
{
	public class PlayerHealthManager : MonoBehaviour
	{
		public int MaxHealth		= 0;
		private int _currentHealth	= 0;
		private bool _isDead		= false;

		private float _maxProtectTime	 = 2.0f;
		private float _currentProtectTime = 0.0f;

		private SceneLoader _sceneLoader;

		void Start()
		{
			GameObject _sceneObj = GameObject.Find("SceneLoader");
			_sceneLoader = _sceneObj.GetComponent<SceneLoader>();

			_currentHealth = MaxHealth;
		}

		void Update()
		{
			if (_currentProtectTime > 0)
			{
				float time = Time.deltaTime;
				_currentProtectTime -= time;

				if (_currentProtectTime <= 0)
					_currentProtectTime = 0;

				//Debug.Log(_currentProtectTime);
			}
		}

		public void TakeDamage()
		{
			if (_currentProtectTime > 0)
				return;

			_currentProtectTime = _maxProtectTime;

			_currentHealth--;

			if (_currentHealth <= 0)
			{
				_isDead = true;
				_currentHealth = 0;

				_sceneLoader.LoadNextScene("LoseScene");
				Destroy(gameObject);
			}

			Debug.Log(_currentHealth);
		}

		public bool IsDead
		{
			get => _isDead;
			//set => _isDead = value;
		}
	}
}
