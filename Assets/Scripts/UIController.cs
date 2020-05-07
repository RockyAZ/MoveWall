using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
	[SerializeField]
	private Button startBtn;
	[SerializeField]
	private Button loseBtn;
	[SerializeField]
	private Button winBtn;


	private void Validator()
	{
		if (startBtn == null)
			Debug.LogError("startBtn == null in UIController");
		if (loseBtn	 == null)
			Debug.LogError("loseBtn == null in UIController");
		if (winBtn	 == null)
			Debug.LogError("winBtn == null in UIController");
	}

	void Awake()
	{
		Validator();
		startBtn.gameObject.SetActive(true);
		loseBtn.gameObject.SetActive(false);
		winBtn.gameObject.SetActive(false);
	}

	/// <summary>
	/// Handle you when game reastarted
	/// </summary>
	public void StartGameHandle()
	{
		startBtn.gameObject.SetActive(false);
		loseBtn.gameObject.SetActive(false);
		winBtn.gameObject.SetActive(false);
	}

	/// <summary>
	/// Handle ui when game win
	/// </summary>
	public void WinShow()
	{
		startBtn.gameObject.SetActive(false);
		loseBtn.gameObject.SetActive(false);
		winBtn.gameObject.SetActive(true);
	}
	/// <summary>
	/// Handle ui when game lose
	/// </summary>
	public void LoseShow()
	{
		startBtn.gameObject.SetActive(false);
		loseBtn.gameObject.SetActive(true);
		winBtn.gameObject.SetActive(false);
	}
}
