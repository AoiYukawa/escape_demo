using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Transform target; // �Ǐ]����Ώۂ̃v���C���[��Transform

	private float distance = 5.0f; // �J�����ƃv���C���[�̋���
	private float height = 10.0f; // �J�����̍���
	private float smoothSpeed = 50.0f; // �J�����̈ړ��X���[�Y��
	
	private Vector3 offset; // �J�����ƃv���C���[�̃I�t�Z�b�g�l

	// Start is called before the first frame update
	void Start()
    {
		// �v���C���[��GameObject��������
		GameObject player = GameObject.Find("Player");

		// �v���C���[��Transform���擾����target�ɐݒ肷��
		if (player != null)
		{
			target = player.transform;
		}
		else
		{
			UnityEngine.Debug.LogError("�v���C���[��������܂���ł����B");
		}

		 offset = new Vector3(0, height, -distance);

	}

	// Update is called once per frame
	void Update()
    {
		// �J�����̖ڕW�ʒu���v�Z
		Vector3 targetPosition = target.position + offset;

		// �J�����̌��݈ʒu����ڕW�ʒu�܂ŃX���[�Y�Ɉړ�
		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

		// �J�����̊p�x���Œ肷��
		Quaternion fixedRotation = Quaternion.Euler(45f, 0f, 0f); // �p�x��ݒ�
		transform.rotation = fixedRotation;

		// �J��������Ƀv���C���[�������낷�悤�Ɍ����𒲐�
		transform.LookAt(target);
	}
}
