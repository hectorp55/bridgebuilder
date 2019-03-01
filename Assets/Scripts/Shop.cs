using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public GameObject[] characters;
	private int currentChar;
	private Vector3 activeShopPosition = new Vector3(-0.1442547f, 0.1740009f, 0f);

	public void rightArrow() {
		characters [currentChar].SetActive (false);
		if (currentChar + 1 >= characters.Length) {
			currentChar = 0;
		} else {
			currentChar++;
		}
		characters [currentChar].SetActive (true);
	}

	public void leftArrow() {
		characters [currentChar].SetActive (false);
		if (currentChar - 1 < 0) {
			currentChar = characters.Length - 1;
		} else {
			currentChar--;
		}
		characters [currentChar].SetActive (true);
	}

	public void selectCharacter() {
		string characterName = characters[currentChar].name;
		SaveGame.updateCharacterSkin (characterName);
	}

	public void unlockCharacter() {
	}

	// Use this for initialization
	void Start () {
		Object[] characterObjs = Resources.LoadAll(Labels.CharacterFolder);
		characters = new GameObject[characterObjs.Length];
		string currentCharacterName = SaveGame.getCharacterName();
		for(int i = 0; i<characterObjs.Length; i++) {
			characters[i] = Instantiate((GameObject)characterObjs[i], activeShopPosition, Quaternion.identity);
			if(characters[i].name == currentCharacterName) {
				currentChar = i;
			}
			else {
				characters[i].SetActive(false);
			}
		}
	}
}
