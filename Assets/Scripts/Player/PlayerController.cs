using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float speed = 1.0f;
		private Rigidbody rb;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

			rb.velocity = dir * speed * Time.deltaTime;
			//transform.position += dir * speed * Time.deltaTime;
		}
	}
}
