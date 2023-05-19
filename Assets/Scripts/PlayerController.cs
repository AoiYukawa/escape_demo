using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		// Unity�̃C���X�y�N�^�[�ő���\�ȕϐ�
		[SerializeField] private float _speed = 1.0f;
		[SerializeField] private Rigidbody _rb;

		private void Update()
		{
			// ����
			Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			// ��������ւ̗͂̋���
			_rb.velocity = dir * _speed * Time.deltaTime;
			// dir�̕����Ɉړ�������
			transform.Translate(dir * _speed * Time.deltaTime);

		}
	}
}
