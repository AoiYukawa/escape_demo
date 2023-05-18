using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Unity.Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		public Rigidbody rb;
		public Vector3 moving, latestPos;
		public float speed;

		void Start()
		{
			rb = GetComponent<Rigidbody>();
			speed = 5;
		}

		void Update()
		{
			MovementControll();
			Movement();
		}

		void FixedUpdate()
		{
			RotateToMovingDirection();
		}
		void MovementControll()
		{
			//�΂߈ړ��Əc���̈ړ��𓯂����x�ɂ��邽�߂�Vector3��Normalize()����B
			moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			moving.Normalize();
			moving = moving * speed;
		}

		public void RotateToMovingDirection()
		{
			Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
			latestPos = transform.position;
			//�ړ����ĂȂ��Ă���]���Ă��܂��̂ŁA���̋����ȏ�ړ��������]������
			if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
			{
				Quaternion rot = Quaternion.LookRotation(differenceDis);
				rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
				this.transform.rotation = rot;
				//�A�j���[�V������ǉ�����ꍇ
				//animator.SetBool("run", true);
			}
			else
			{
				//animator.SetBool("run", false);
			}
		}

		void Movement()
		{
			rb.velocity = moving;
		}
	}
}
