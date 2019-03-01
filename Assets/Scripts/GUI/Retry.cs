using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour {

	public Text score;
	public Text highscore;

	// Use this for initialization
	void Start () {
		highscore.text = SaveGame.getHighScore ().ToString();
		score.text = SaveGame.getLastScore ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
