using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planks_Animation : MonoBehaviour {

	public List<Sprite> planks;

	private int planks_in_pile;
	private SpriteRenderer sprite_render;
	private Game_Manager manager;
	private Ground ground_script;

	// Use this for initialization
	void Awake () {
		sprite_render = GetComponent<SpriteRenderer> ();
	}

	void Start() {
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Game_Manager> ();
		ground_script = GetComponent<Ground> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (ground_script.transperant || manager.planks_in_stack <= -1) {
			planks_in_pile = 0;
		} else if (manager.planks_in_stack >= 9) {
			planks_in_pile = 9;
		}
		else {
			planks_in_pile = manager.planks_in_stack;	
		}

		sprite_render.sprite = planks [planks_in_pile];
	}
}
