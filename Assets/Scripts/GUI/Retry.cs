using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour {

	public Text score;
	public Text highscore;

	private SaveGame save;

	// Use this for initialization
	void Start () {
		save = GetComponent<SaveGame> ();
		highscore.text = save.getHighScore ().ToString();
		score.text = save.getLastScore ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
