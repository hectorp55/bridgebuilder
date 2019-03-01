using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Builder : MonoBehaviour {

	public Vector3 builder_location;
	public Vector3 curr_vel;
	public GameObject plank_prefab;
	public GameObject bigger_plank_prefab;
	public Animator animator;
	public bool continue_move;

	private Game_Manager manager;
	private Rigidbody builder_body;
	private Collider builder_coll;
	private float speed;
	private List<GameObject> planks;
	private Vector3 plank_place;
	private Vector3 initial_build_location;
	private Vector3 plank_offset;
	private SpriteRenderer sprite_render;
	private bool playerHasLost = false;

	//===============================================
	//Public Members
	//===============================================

	public void destroyLastPlank() {
		Destroy(planks[planks.Count-1]);
		planks.RemoveAt(planks.Count-1);
	}

	public void transparent_pickup() {
		animator.SetBool ("Holding_Plank", true);
		manager.decrease_stack ();
	}

	public void fallPlayer() {
		playerHasLost = true;
		Destroy (builder_coll);
		curr_vel = new Vector3 (0f, -1f, 0f);
		foreach (var plank in planks) {
			plank.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	//Drops plank from hand and flips player
	public void drop_plank() {
		animator.SetBool ("Holding_Plank", false);
		StartCoroutine(hammerStall());
		StartCoroutine(plank_to_environment());
	}

	//Picks up plank from pile and flips player
	public void pickup_plank() {
		animator.SetBool ("Holding_Plank", true);
		manager.decrease_stack ();
		turnPlayer ();
	}

	public void drop_bigger_plank(Vector3 location) {
		animator.SetBool ("Holding_Plank", false);
		StartCoroutine(hammerStall());
		planks.Add(create_bigger_plank (location));
	}

	//===============================================
	//Private Members
	//===============================================

	private IEnumerator plank_to_environment() {
		yield return new WaitForSeconds(0.5f);
		planks.Add(create_plank ());
	}

	//Stalls player for hammer animation
	private IEnumerator hammerStall() {
		curr_vel = Vector3.zero;
		yield return new WaitForSeconds(1);
		curr_vel = Vector3.right;
		if (!continue_move) {
			turnPlayer ();
		} else {
			continue_move = false;
		}
	}

	//Turns player around
	private void turnPlayer() {
		curr_vel = new Vector3(curr_vel.x * -1, curr_vel.y, curr_vel.z);
		transform.localScale = (new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z));
	}

	private GameObject create_plank() {
		return ((GameObject)Instantiate (plank_prefab, plank_place, Quaternion.identity));
	}

	private GameObject create_bigger_plank(Vector3 location) {
		return ((GameObject)Instantiate (bigger_plank_prefab, location, Quaternion.identity));
	}
		
	//===============================================
	//Game Function
	//===============================================
	void Awake() {
		builder_body = GetComponent<Rigidbody> ();
		sprite_render = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator> ();
		builder_coll = GetComponent<Collider> ();
		planks = new List<GameObject> ();
		plank_offset = new Vector3 (3.0f, -1.95f, 0f);

		//Initial Speed and velocity
		speed = 0;
		curr_vel = Vector3.right;
		Time.timeScale = 0;

		//Start holding a plank
		animator.SetBool ("Holding_Plank", true);
		// sprite_render.sprite = CharacterLoad.LoadCharacter().playerSkin;
	}

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Game_Manager> ();
		initial_build_location = transform.position;
	}
	
	// Update speed every frame
	void FixedUpdate () {
		builder_body.velocity = curr_vel * speed;
	}

	void Update() {
		builder_location = transform.position;
		plank_place = new Vector3 (builder_location.x, initial_build_location.y, builder_location.z) + plank_offset;

		if (speed < 20f) {
			//Pre determined Speed
			speed = Time.timeSinceLevelLoad * (11f / 45f) + 3f;
		}

		//Input drops plank
		if(Input.GetButtonDown("Drop") && animator.GetBool("Holding_Plank") && Time.timeScale != 0 && !playerHasLost) {
			drop_plank ();
		}

		//Input drops plank
		foreach(Touch touch in Input.touches) {
			if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId) && touch.phase == TouchPhase.Began) {
				if(animator.GetBool("Holding_Plank") && Time.timeScale != 0 && !playerHasLost) {
					drop_plank ();
				}
			}
		}
	}
		
}
