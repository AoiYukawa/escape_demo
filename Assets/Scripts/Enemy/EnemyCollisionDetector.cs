using System.Collections;
using System.Collections.Generic;
using Unity.Assets.Scripts.Player;
using UnityEngine;

namespace Unity.Assets.Scripts.Enemy
{
	public class EnemyCollisionDetector : MonoBehaviour
	{
		private GameObject _player;
		private PlayerHealthManager _healthManager;

		void Start()
		{
			_player = GameObject.Find("Player");
			_healthManager = _player.GetComponent<PlayerHealthManager>();
		}

		void Update()
		{

		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.name == "Player")
				_healthManager.TakeDamage();
		}
	}
}
