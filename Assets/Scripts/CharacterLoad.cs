using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad {
	// Use this for initialization

	public static CharacterSkin LoadCharacter() {
		string characterName = SaveGame.getCharacterName();
		string plankName = SaveGame.getPlankName();
		
		Object characterSkinObj = Resources.Load("Characters/" + characterName);
		Object plankSkinObj = Resources.Load("Planks/" + plankName);

		Debug.Log(characterName);
		GameObject characterSkinGame = (GameObject)characterSkinObj;
		GameObject plankSkinGame = (GameObject)plankSkinObj;

		Sprite characterSkin = characterSkinGame.GetComponent<SpriteRenderer>().sprite; 
		Sprite plankSkin = plankSkinGame.GetComponent<SpriteRenderer>().sprite;

		return new CharacterSkin(characterSkin, plankSkin);
	}
}
