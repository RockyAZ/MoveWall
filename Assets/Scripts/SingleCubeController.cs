using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCubeController : MonoBehaviour
{
	private Vector3 targetPos;
	private float speed;

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
		this.gameObject.layer = 0;
		StartCoroutine(MoveCor());
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
		Vector3 tmpV = transform.position;
		tmpV.y = 0;
		this.transform.position = tmpV;
		yield break;
	}

}
