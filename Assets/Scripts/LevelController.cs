using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	/*IMPORTANT INFO
	about lvl creations:
	1 = simple cube that cant move
	2 = empty space, and following with this space cube stay 1 block up
	3 = empty space, and following with this space cube stay 1 block righ
	4 = empty space, and following with this space cube stay 1 block down
	5 = empty space, and following with this space cube stay 1 block left
	6 = just above empty space

	1 = <>
	2 = up
	3 = right
	4 = down
	5 = left
	6 = just above
	Clockwise positions!
	*/

	private static LevelController instance;
	public static LevelController Instance { get => instance; }

	public const int H = 14;
	public const int W = 5;
	private int[,] lvlStartData = new int[H, W] {
											 { 1, 1, 1, 1, 1 },//this is end
											 { 1, 1, 6, 1, 1 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 6, 1, 6, 1 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 1, 6, 1, 1 },
											 { 1, 6, 6, 6, 6 },
											 { 1, 1, 1, 1, 1 },
											 { 6, 1, 6, 1, 6 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 1, 1, 1, 1 },
											 { 1, 1, 1, 1, 1 } };//this is start and this row where whall appears
	//Game values to set
	private UIController uIController;
	[SerializeField]
	private float cubeSpeed = 1;
	public float CubeSpeed { get => cubeSpeed; }
	[SerializeField]
	private float wallSpeed = 1;
	public float WallSpeed { get => wallSpeed; }

	//prefabs to set
	[SerializeField]
	private GameObject cubePref;
	[SerializeField]
	private WallController wall;

	//In-game values
	private GameObject parentCube;


	private void Validator()
	{
		if (uIController == null)
			Debug.LogError("uIController == null in LevelCOntroller");
		if (cubeSpeed <= 0)
			Debug.LogError("cubeSpeed == 0 in LevelCOntroller");
		if (cubePref == null)
			Debug.LogError("cubewPref == null in LevelCOntroller");
		if (wall == null)
			Debug.LogError("wall == null in LevelCOntroller");
	}

	private void Awake()
	{
		//Handle Singleton things
		if (instance == null)
			instance = this;
		//set uiController if it exists in current gmeObject
		uIController = this.gameObject.GetComponent<UIController>();
		Validator();
		parentCube = new GameObject("ParentCube");
	}

	public void StartGame()
	{
		CreateLevel();
		wall.StartGame();
		uIController.StartGameHandle();
	}

	public void RestartGame()
	{
		StartGame();
	}

	/// <summary>
	/// stop game when win or lose
	/// </summary>
	/// <param name="isWin"> set win or lose handle</param>
	public void StopGame(bool isWin)
	{
		if (isWin)
			uIController.WinShow();
		else
			uIController.LoseShow();
		//delete all cube
		foreach (Transform child in parentCube.transform)
			GameObject.Destroy(child.gameObject);
	}

	/// <summary>
	/// set cubes and wall
	/// </summary>
	private void CreateLevel()
	{
		//set wall
		wall.transform.position = new Vector3(1, 2.5f, (W + 1) / 2);
		wall.TargetPos = new Vector3(H + 1, 2.5f, (W + 1) / 2);

		//value handling for each cube in lvlInfo
		for (int i = 0; i < H; i++)
		{
			for (int j = 0; j < W; j++)
			{
				//create cube
				GameObject tmp = Instantiate(cubePref, Vector3.zero, Quaternion.identity);
				Vector3 niceVector = new Vector3(H - i, 0, W - j);
				tmp.transform.position = niceVector;
				tmp.transform.parent = parentCube.transform;

				//add active cube component
				tmp.AddComponent<SingleCubeController>();
				SingleCubeController tmpCube = tmp.GetComponent<SingleCubeController>();
				if (tmpCube == null)
					Debug.LogError("cant instantiate cube correctly");

				//change active cube color
				tmp.GetComponent<MeshRenderer>().material.color = Color.blue;

				//delete useless components if cube is not active
				if (lvlStartData[i, j] == 1)
				{
					tmp.GetComponent<MeshRenderer>().material.color = Color.white;
					Destroy(tmp.GetComponent<Rigidbody>());
					Destroy(tmp.GetComponent<BoxCollider>());
					continue;
				}
				//handle each type of active cubes
				else if (lvlStartData[i, j] == 2)
				{
					tmp.transform.position = new Vector3(H - i + 1, 1, W - j);
					tmpCube.TargetPos = niceVector;
				}
				else if (lvlStartData[i, j] == 3)
				{
					tmp.transform.position = new Vector3(H - i, 1, W - j - 1);
					tmpCube.TargetPos = niceVector;
				}
				else if (lvlStartData[i, j] == 4)
				{
					tmp.transform.position = new Vector3(H - i - 1, 1, W - j);
					tmpCube.TargetPos = niceVector;
				}
				else if (lvlStartData[i, j] == 5)
				{
					tmp.transform.position = new Vector3(H - i, 1, W - j + 1);
					tmpCube.TargetPos = niceVector;
				}
				else if (lvlStartData[i, j] == 6)
				{
					tmp.transform.position = new Vector3(H - i, 1, W - j);
					tmpCube.TargetPos = niceVector;
				}
				else
					Debug.LogError("Bad value in lvlStartData in LevelController | " + i + " | " + j + " |");
			}
		}
	}

}
