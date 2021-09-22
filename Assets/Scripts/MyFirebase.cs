using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

public class MyFirebase : MonoBehaviour
{
	public static MyFirebase Instance { get; private set; }
	public static bool done;
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
		{
			//FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
			var app = FirebaseApp.DefaultInstance;
			done = true;
		});
	}

	public void ClickEvent()
	{
		//firebase
		FirebaseAnalytics.LogEvent("program_mob_pristriy_23_09_2021",
new Parameter("my_parametr_name", 123123));
	}
}
