using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adventure.Player;

namespace Unity.Assets.Scripts.UI
{
	public class UIManager : MonoBehaviour
	{
		private PlayerStatus _playerStatus;
		private HealthBar _healthBar;

		void Start()
		{
			GameObject player = GameObject.Find("Player");
			_playerStatus = player.GetComponent<PlayerStatus>();

			GameObject healthBar = GameObject.Find("HealthBar");
			_healthBar = healthBar.GetComponent<HealthBar>();

			_healthBar.SetMaxHealth(_playerStatus.MaxHealth);
		}

		void Update()
		{
			_healthBar.SetHealth(_playerStatus.CurrentHealth);
		}
	}
}
