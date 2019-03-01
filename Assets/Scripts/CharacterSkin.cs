using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkin {

	public readonly Sprite playerSkin;
	public readonly Sprite plankSkin;

	public CharacterSkin(Sprite player, Sprite plank) {
		playerSkin = player;
		plankSkin = plank;
	}
}
