using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCubeController : MonoBehaviour
{
	private Vector3 targetPos;
	private float speed;
	private bool moving;//to avoid bugs

	/// <summary>
	/// Where cube should move if clicked
	/// </summary>
	public Vector3 TargetPos { get => targetPos;
		set
		{
			targetPos = value;
			targetPos.y = 1;
		}
	}

	void Start()
	{
		speed = LevelController.Instance.CubeSpeed;
		if (targetPos == null)
			Debug.LogError("targetPos == null in SingleCubeController, in " + this.gameObject.name);
	}

	/// <summary>
	/// Calculate direction to target and move cube
	/// </summary>
	public void Move()
	{
		if (!moving)
		{
			moving = true;
			StartCoroutine(MoveCor());
		}
	}

	IEnumerator MoveCor()
	{
		while (this.transform.position != targetPos)
		{
			Vector3 checker = this.transform.position;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPos, speed * Time.deltaTime);
			if (checker == this.transform.position)
				break;
			yield return 0;
		}
		StartCoroutine(MoveDown());
		yield break;
	}

	IEnumerator MoveDown()
	{
		Vector3 tmpV = transform.position;
		tmpV.y = 0;
		targetPos = tmpV;
		while (transform.position != targetPos)
		{
			Vector3 checker = this.transform.position;
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPos, speed * Time.deltaTime);
			if (checker == this.transform.position)
				break; yield return 0;
		}
		//delete opportunity to get collision with wall
		this.gameObject.layer = 0;
		yield break;
	}

}
