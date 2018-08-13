using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	//Private Members
	//----------------------------------------------------------------------------------
	
	private Builder control;
	private Game_Manager main_script;
	private GameObject builder;
	private GameObject main;
	private BGMover bgMover;

	//Public Static Members
	//----------------------------------------------------------------------------------
	
	//Public Members
	//----------------------------------------------------------------------------------

	public bool transperant;
	
	//Functions
	//----------------------------------------------------------------------------------
	
	// Use this for initialization
	void Start () {
		builder = GameObject.FindWithTag("Player");
		main = GameObject.FindWithTag ("Manager");
		bgMover = main.GetComponent<BGMover> ();
		main_script = main.GetComponent<Game_Manager> ();
		control = builder.GetComponent<Builder> ();

	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			if (!transperant) {
				control.pickup_plank();
			}
			if(transperant) {
				transperant = false;
				main_script.ground_shift ();
				bgMover.shiftBG ();
				control.transparent_pickup ();
				main_script.scored ();
			}
		}
	}
}