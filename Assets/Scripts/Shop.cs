using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public List<GameObject> characters;

	private int currentChar;
	private SaveGame save;

	public void rightArrow() {
		characters [currentChar].SetActive (false);
		if (currentChar + 1 >= characters.Count) {
			currentChar = 0;
		} else {
			currentChar++;
		}
		characters [currentChar].SetActive (true);
	}

	public void leftArrow() {
		characters [currentChar].SetActive (false);
		if (currentChar - 1 < 0) {
			currentChar = characters.Count - 1;
		} else {
			currentChar--;
		}
		characters [currentChar].SetActive (true);
	}

	public void selectCharacter() {
		save.updateCharacter (currentChar);
	}

	public void unlockCharacter() {
	}

	// Use this for initialization
	void Start () {
		currentChar = 0;
		characters [currentChar].SetActive (true);
		save = GetComponent<SaveGame> ();
	}
}
