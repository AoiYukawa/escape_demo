using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Assets.Scripts.Camera
{
	public class CameraShake : MonoBehaviour
	{
		[SerializeField] private float _duration = 0.15f;
		[SerializeField] private float _magnitude = 0.1f;

		public IEnumerator Shake()
		{
			Vector3 originalPos = transform.position;

			float elapsed = 0.0f;

			while (elapsed < _duration)
			{
				float x = originalPos.x + Random.Range(-1.0f, 1.0f) * _magnitude;
				float y = originalPos.y + Random.Range(-1.0f, 1.0f) * _magnitude;
				float z = originalPos.z + Random.Range(-1.0f, 1.0f) * _magnitude;

				transform.position = new Vector3(x, y, z);

				elapsed += Time.deltaTime;

				yield return null;
			}

			transform.position = originalPos;
		}
	}

}
