using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Assets.Scripts.Camera
{
	public class CameraController : MonoBehaviour
	{
		GameObject player;
		private Transform target;

		private float distance = 5.0f;
		private float height = 10.0f;
		private float smoothSpeed = 10.0f;

		private Vector3 offset;

		void Start()
		{
			player = GameObject.Find("Player");

			if (player != null)
			{
				target = player.transform;
			}
			else
			{
				UnityEngine.Debug.LogError("The player object could not be found.");
			}

			offset = new Vector3(0, height, -distance);

		}

		void Update()
		{
			if (player == null) return;

			Vector3 targetPosition = target.position + offset;

			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

			transform.LookAt(target);
		}
	}
}
