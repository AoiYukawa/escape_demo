using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Assets.Scripts.Scene;
using Unity.Assets.Scripts.Camera;

namespace Adventure.Player
{
	public class PlayerStatus : MonoBehaviour
	{
		[SerializeField] int _maxHealth = 1;
		[SerializeField] float _maxProtectTime = 2.0f;

		int _currentHealth = 0;
		float _currentProtectTime = 0.0f;
		bool _isDead = false;

		//PlayerAttribute _playerAttribute;

		SceneLoader _sceneLoader;

		CameraShake _cameraShake;

		void Start()
		{
			GameObject sceneObj = GameObject.Find("SceneLoader");
			_sceneLoader = sceneObj.GetComponent<SceneLoader>();

			GameObject cameraObj = GameObject.Find("Main Camera");
			_cameraShake = cameraObj.GetComponent<CameraShake>();

			_currentHealth = _maxHealth;
		}

		void Update()
		{
			ProccesSequence();

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

			StartCoroutine(_cameraShake.Shake());

			Debug.Log(_currentHealth);
		}

		void ProccesSequence()
		{
			if (_currentHealth <= 0)
			{
				_isDead = true;
				_currentHealth = 0;

				_sceneLoader.LoadNextScene("LoseScene");
				Destroy(gameObject);
			}
		}

		public int MaxHealth
		{
			get => _maxHealth;
			set => _maxHealth = value;
		}
		public int CurrentHealth
		{
			get => _currentHealth;
			set => _currentHealth = value;
		}
		public bool IsDead
		{
			get => _isDead;
			//set => _isDead = value;
		}
	}
}
