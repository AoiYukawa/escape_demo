using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		public float moveSpeed = 5f;  // �I�u�W�F�N�g�̈ړ����x
		
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			float verticalInput = Input.GetAxis("Vertical");

			// WASD�L�[�̓��͂ɉ����ăI�u�W�F�N�g���ړ�������
			Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
			transform.Translate(movement);
		}
	}
}
