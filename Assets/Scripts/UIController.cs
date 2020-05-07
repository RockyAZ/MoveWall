using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
	[SerializeField]
	private GameObject startUI;
	[SerializeField]
	private GameObject loseUI;
	[SerializeField]
	private GameObject winUI;


	private void Validator()
	{
		if (startUI == null)
			Debug.LogError("startUI == null in UIController");
		if (loseUI	 == null)
			Debug.LogError("loseUI == null in UIController");
		if (winUI	 == null)
			Debug.LogError("winUI == null in UIController");
	}

	void Awake()
	{
		Validator();
		startUI.gameObject.SetActive(true);
		loseUI.gameObject.SetActive(false);
		winUI.gameObject.SetActive(false);
	}

	/// <summary>
	/// Handle you when game reastarted
	/// </summary>
	public void StartGameHandle()
	{
		startUI.gameObject.SetActive(false);
		loseUI.gameObject.SetActive(false);
		winUI.gameObject.SetActive(false);
	}

	/// <summary>
	/// Handle ui when game win
	/// </summary>
	public void WinShow()
	{
		startUI.gameObject.SetActive(false);
		loseUI.gameObject.SetActive(false);
		winUI.gameObject.SetActive(true);
	}
	/// <summary>
	/// Handle ui when game lose
	/// </summary>
	public void LoseShow()
	{
		startUI.gameObject.SetActive(false);
		loseUI.gameObject.SetActive(true);
		winUI.gameObject.SetActive(false);
	}
}
