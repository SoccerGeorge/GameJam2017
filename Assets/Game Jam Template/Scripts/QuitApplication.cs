using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {
	ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels

	void Awake () {
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();
	}

	public void ShowCredits () {
		showPanels.ShowCreditsPanel();
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		Invoke("Quit", 2f);
	}

	public void Quit()
	{
		//If we are running in a standalone build of the game
	#if UNITY_STANDALONE || UNITY_ANDROID
		//Quit the application
		Application.Quit();
	#endif

		//If we are running in the editor
	#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}
}
