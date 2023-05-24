using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Assets.Scripts.Player
{
	public class PlayerHealthManager : MonoBehaviour
	{
		private int _maxHealth		= 5;
		private int _currentHealth	= 0;
		private bool _isDead			= false;

		private float _maxProtectTime	 = 2.0f;
		private float _currentProtectTime = 0.0f;

		void Start()
		{
			_currentHealth = _maxHealth;
		}

		void Update()
		{
			if (_currentProtectTime > 0)
			{
				float time = Time.deltaTime;
				_currentProtectTime -= time;

				if (_currentProtectTime <= 0)
					_currentProtectTime = 0;

				Debug.Log(_currentProtectTime);
			}
		}

		public void TakeDamage()
		{
			if (_currentProtectTime > 0)
				return;

			_currentHealth--;

			_currentProtectTime = _maxProtectTime;

			if (_currentHealth < 0)
			{
				_currentHealth = 0;
				return;
			}

			if (_currentHealth == 0)
			{
				_isDead = true;
				Destroy(gameObject);
			}

			Debug.Log(_currentHealth);
		}

		public bool IsDead() { return  _isDead; }
	}
}
