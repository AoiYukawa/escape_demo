using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adventure.Player;

namespace Unity.Assets.Scripts.Enemy
{
	public class EnemyCollisionDetector : MonoBehaviour
	{
		private GameObject _player;
		private PlayerStatus _playerStatus;

		void Start()
		{
			_player = GameObject.Find("Player");
			_playerStatus = _player.GetComponent<PlayerStatus>();
		}

		void Update()
		{

		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.name == "Player")
				_playerStatus.TakeDamage();
		}
	}
}
