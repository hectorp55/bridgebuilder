using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {

	public void updateHighScore(int n) {
		if(getHighScore() < n) {
			PlayerPrefs.SetInt("HighScore", n);	
		}
	}

	public void updateCharacter(int n) {
		PlayerPrefs.SetInt("Character", n);
	}

	public void updateBoltCount(int n) {
		int bolts = getBoltCount ();
		PlayerPrefs.SetInt ("Bolts", (bolts + n));
	}

	public void updateLastScore(int n) {
		PlayerPrefs.SetInt("LastScore", n);
	}

	public void updateTutorial(int n) {
		PlayerPrefs.SetInt ("Tutorial", n);
	}

	public int getHighScore() {
		if (PlayerPrefs.HasKey ("HighScore")) {
			return PlayerPrefs.GetInt ("HighScore");	
		} else {
			return 0;
		}
	}

	public int getSelectedCharacter() {
		if (PlayerPrefs.HasKey ("Character")) {
			return PlayerPrefs.GetInt ("Character");	
		} else {
			return 0;
		}
	}

	public int getBoltCount() {
		if (PlayerPrefs.HasKey ("Bolts")) {
			return PlayerPrefs.GetInt ("Bolts");
		} else {
			return 0;
		}
	}

	public int getLastScore() {
		if (PlayerPrefs.HasKey ("LastScore")) {
			return PlayerPrefs.GetInt ("LastScore");
		} else {
			return 0;
		}
	}

	public int getTutorial() {
		if (PlayerPrefs.HasKey ("Tutorial")) {
			return PlayerPrefs.GetInt ("Tutorial");
		} else {
			return 1;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
