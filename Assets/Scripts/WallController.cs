using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	private float speed;

	private bool movable;
	/// <summary>
	/// Wall can move
	/// </summary>
	public bool Movable { get => movable; set => movable = value; }

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
		{
			trans.position = Vector3.MoveTowards(trans.position, targetPos, speed * Time.deltaTime);
			if (trans.position == TargetPos)
			{
				movable = false;
				LevelController.Instance.StopGame(true);
			}
		}
	}

	public void StartGame()
	{
		movable = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		SingleCubeController tmpCube = collision.gameObject.GetComponent<SingleCubeController>();
		if (tmpCube != null)
		{
			LevelController.Instance.StopGame(false);
			movable = false;
		}
	}

}
