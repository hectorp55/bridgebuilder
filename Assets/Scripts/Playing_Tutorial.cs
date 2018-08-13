using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playing_Tutorial : MonoBehaviour {

	public GameObject[] tutorialPages;
	int currentTutorialIndex;

	// Use this for initialization
	void Start () {
		currentTutorialIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown || Input.touchCount > 0) {
			nextTutorialPage ();
		}
	}

	void nextTutorialPage() {
		if (currentTutorialIndex+1 >= tutorialPages.Length) {
			loadGame ();
		} 
		else {
			tutorialPages [currentTutorialIndex].SetActive (false);
			currentTutorialIndex++;
			tutorialPages [currentTutorialIndex].SetActive (true);
		}
	}

	void loadGame() {
		SceneManager.LoadScene ("main");
	}
}
