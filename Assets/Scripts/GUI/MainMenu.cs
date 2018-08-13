using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private SaveGame save;
	public bool tutorial;

	public void playGame() {
		if(save.getTutorial() == 1) {
			save.updateTutorial (0);
			SceneManager.LoadScene ("Tutorial");
		}
		SceneManager.LoadScene ("main");
	}

	public void openOptions() {
		SceneManager.LoadScene ("Options");
	}

	public void openShop() {
		SceneManager.LoadScene ("Shop");
	}

	public void returnHome() {
		SceneManager.LoadScene ("Title");
	}

	// Use this for initialization
	void Start () {
		save = GetComponent<SaveGame> ();
		if (save.getTutorial () == 1) {
			tutorial = true;
		} else {
			tutorial = false;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (tutorial) {
			save.updateTutorial (1);
		} else {
			save.updateTutorial (0);
		}
	}
}
