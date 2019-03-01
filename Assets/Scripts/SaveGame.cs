using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {
	public static void updateHighScore(int n) {
		if(getHighScore() < n) {
			PlayerPrefs.SetInt(Labels.HighScore, n);	
		}
	}

	public static void updateBoltCount(int n) {
		int bolts = n;
		PlayerPrefs.SetInt (Labels.Bolts, bolts);
	}

	public static void updateLastScore(int n) {
		PlayerPrefs.SetInt(Labels.LastScore, n);
	}

	public static void updateTutorial(int n) {
		PlayerPrefs.SetInt (Labels.Tutorial, n);
	}

	public static void updateCharacterSkin(string name) {
		PlayerPrefs.SetString (Labels.CharacterSkin, name);
	}

	public static string getCharacterName() {
		if(PlayerPrefs.HasKey(Labels.CharacterSkin)) {
			return PlayerPrefs.GetString(Labels.CharacterSkin);
		}
		else {
			return Labels.DefaultCharacter;
		}
	}

	public static string getPlankName() {
		if(PlayerPrefs.HasKey(Labels.PlankSkin)) {
			return PlayerPrefs.GetString(Labels.PlankSkin);
		}
		else {
			return Labels.DefaultCharacter;
		}
	}

	public static int getHighScore() {
		if (PlayerPrefs.HasKey (Labels.HighScore)) {
			return PlayerPrefs.GetInt (Labels.HighScore);	
		} else {
			return 0;
		}
	}

	public static int getBoltCount() {
		if (PlayerPrefs.HasKey (Labels.Bolts)) {
			return PlayerPrefs.GetInt (Labels.Bolts);
		} else {
			return 0;
		}
	}

	public static int getLastScore() {
		if (PlayerPrefs.HasKey (Labels.LastScore)) {
			return PlayerPrefs.GetInt (Labels.LastScore);
		} else {
			return 0;
		}
	}

	public static int getTutorial() {
		if (PlayerPrefs.HasKey (Labels.Tutorial)) {
			return PlayerPrefs.GetInt (Labels.Tutorial);
		} else {
			return 1;
		}
	}
}
