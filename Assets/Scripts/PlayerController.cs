using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		// Unityのインスペクターで操作可能な変数
		[SerializeField] private float _speed = 1.0f;
		[SerializeField] private Rigidbody _rb;

		private void Update()
		{
			// 方向
			Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			// ある方向への力の強さ
			_rb.velocity = dir * _speed * Time.deltaTime;
			// dirの方向に移動させる
			transform.Translate(dir * _speed * Time.deltaTime);

		}
	}
}
