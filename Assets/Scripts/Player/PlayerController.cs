using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed = 1.0f;
		private Rigidbody _rb;

		private void Start()
		{
			_rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

			_rb.velocity = dir * _speed * Time.deltaTime;
			//transform.position += dir * speed * Time.deltaTime;
		}
	}
}
