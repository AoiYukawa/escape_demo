using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Assets.Scripts.Player
{
	public class PlayerHealthManager : MonoBehaviour
	{
		private int maxHealth = 5;
		private int currentHealth = 0;

		private float maxProtectTime = 2.0f;
		private float currentProtectTime = 0.0f;

		void Start()
		{
			currentHealth = maxHealth;
		}

		void Update()
		{
			if (currentProtectTime > 0)
			{
				float value = Time.deltaTime;
				currentProtectTime -= value;

				if (currentProtectTime <= 0)
					currentProtectTime = 0;

				Debug.Log(currentProtectTime);
			}
		}

		public void TakeDamage()
		{
			if (currentProtectTime > 0)
				return;

			currentHealth--;

			currentProtectTime = maxProtectTime;


			if (currentHealth < 0)
			{
				currentHealth = 0;
				return;
			}

			if (currentHealth == 0)
			{
				Destroy(gameObject);
			}

			Debug.Log(currentHealth);
		}
	}
}
