using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Transform target; // 追従する対象のプレイヤーのTransform

	private float distance = 5.0f; // カメラとプレイヤーの距離
	private float height = 10.0f; // カメラの高さ
	private float smoothSpeed = 50.0f; // カメラの移動スムーズさ
	
	private Vector3 offset; // カメラとプレイヤーのオフセット値

	// Start is called before the first frame update
	void Start()
    {
		// プレイヤーのGameObjectを見つける
		GameObject player = GameObject.Find("Player");

		// プレイヤーのTransformを取得してtargetに設定する
		if (player != null)
		{
			target = player.transform;
		}
		else
		{
			UnityEngine.Debug.LogError("プレイヤーが見つかりませんでした。");
		}

		 offset = new Vector3(0, height, -distance);

	}

	// Update is called once per frame
	void Update()
    {
		// カメラの目標位置を計算
		Vector3 targetPosition = target.position + offset;

		// カメラの現在位置から目標位置までスムーズに移動
		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

		// カメラの角度を固定する
		Quaternion fixedRotation = Quaternion.Euler(45f, 0f, 0f); // 角度を設定
		transform.rotation = fixedRotation;

		// カメラが常にプレイヤーを見下ろすように向きを調整
		transform.LookAt(target);
	}
}
