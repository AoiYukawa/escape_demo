using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed = 1.0f;

		private void Update()
		{
			Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			transform.Translate(dir * _speed * Time.deltaTime);
		}
	}
}
