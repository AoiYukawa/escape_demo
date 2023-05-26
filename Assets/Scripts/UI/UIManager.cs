using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Assets.Scripts.Player;

namespace Unity.Assets.Scripts.UI
{
	public class UIManager : MonoBehaviour
	{
		private PlayerHealthManager _playerHealthManager;
		private HealthBar _healthBar;

		void Start()
		{
			GameObject player = GameObject.Find("Player");
			_playerHealthManager = player.GetComponent<PlayerHealthManager>();

			GameObject healthBar = GameObject.Find("HealthBar");
			_healthBar = healthBar.GetComponent<HealthBar>();

			_healthBar.SetMaxHealth(_playerHealthManager.MaxHealth);
		}

		void Update()
		{
			_healthBar.SetHealth(_playerHealthManager.CurrentHealth);
		}
	}
}
