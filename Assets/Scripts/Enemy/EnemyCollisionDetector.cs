using System.Collections;
using System.Collections.Generic;
using Unity.Assets.Scripts.Player;
using UnityEngine;

namespace Unity.Assets.Scripts.Enemy
{
	public class EnemyCollisionDetector : MonoBehaviour
	{
		GameObject player;
		PlayerHealthManager healthManager;

		void Start()
		{
			player = GameObject.Find("Player");
			healthManager = player.GetComponent<PlayerHealthManager>();
		}

		void Update()
		{

		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.name == "Player")
				healthManager.TakeDamage();
		}
	}
}
