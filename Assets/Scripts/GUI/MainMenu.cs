﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	//Toggle Values
	public Toggle tutorialToggle;

	//UI Routes
	public GameObject optionsObject;
	public GameObject mainTitleObject;

	//=======================================================
	// Public Functions
	//=======================================================

	public void playGame() {
		if(SaveGame.getTutorial() == 1) {
			SaveGame.updateTutorial (0);
			SceneManager.LoadScene ("Tutorial");
		} else {
			SceneManager.LoadScene ("main");
		}
	}

	public void openOptions() {
		switchUI(mainTitleObject, optionsObject);
		tutorialToggle.isOn = SaveGame.getTutorial() == 1;
	}

	public void openShop() {
		SceneManager.LoadScene ("Shop");
	}

	public void returnHome() {
		switchUI(optionsObject, mainTitleObject);
	}

	public void navigateHome() {
		SceneManager.LoadScene ("Title");
	}

	public void updateTutorial(bool value) {
		int tutValue = 0;
		if (value) tutValue = 1; 
		SaveGame.updateTutorial(tutValue);
	}

	//=======================================================
	// Game Methods
	//=======================================================

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	//=======================================================
	// Private Functions
	//=======================================================

	private void switchUI(GameObject uiObjectOff, GameObject uiObjectOn) {
		uiObjectOff.SetActive(false);
		uiObjectOn.SetActive(true);
	}
}
