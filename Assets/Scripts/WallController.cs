using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	private float speed;
	private bool movable;
	private Transform trans;

	private Vector3 targetPos;
	/// <summary>
	/// Where wall should move
	/// </summary>
	public Vector3 TargetPos { get => targetPos; set => targetPos = value; }

	void Start()
	{
		speed = LevelController.Instance.WallSpeed;
		trans = this.gameObject.GetComponent<Transform>();
	}

	void Update()
	{
		if (movable)
			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
	}
}
