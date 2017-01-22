using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	public Transform tutorialRoot;
	int child = 0;
	ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels

	void Awake () {
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

	}

	public void TutorialClicked () {
		if (child == 3) {
			tutorialRoot.GetChild(0).gameObject.SetActive(true);
			tutorialRoot.GetChild(3).gameObject.SetActive(false);
			child = 0;
			showPanels.HideTutorialPanel();
		}
		else {
			tutorialRoot.GetChild(child).gameObject.SetActive(false);
			child++;
			tutorialRoot.GetChild(child).gameObject.SetActive(true);
		}
	}
}
