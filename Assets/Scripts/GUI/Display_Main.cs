using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Main : MonoBehaviour {

	public Text planks_left;
	public Text score;
	public Text bolts;
	public Button play;
	public Button pause;
	public Button exit;
	public Button startButton;

	private Game_Manager manager;

	public void pauseGame() {
		Time.timeScale = 0;
		pause.gameObject.SetActive(false);
		play.gameObject.SetActive(true);
		exit.gameObject.SetActive(true);
	}

	public void unpauseGame() {
		Time.timeScale = 1;
		pause.gameObject.SetActive(true);
		play.gameObject.SetActive(false);
		exit.gameObject.SetActive(false);
	}

	public void exitGame() {
		Time.timeScale = 1;
		manager.loser ();
	}

	public void startGame() {
		startButton.gameObject.SetActive(false);
		manager.startMovingPlayer();
	}

	//===============================================
	//Game Function
	//===============================================

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Game_Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		planks_left.text = manager.planks_in_stack.ToString();
		score.text = manager.score.ToString ();
		bolts.text = manager.boltCount.ToString ();
	}
}
