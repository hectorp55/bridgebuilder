using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

	public GameObject initial_ground;
	public GameObject ground_prefab;
	public GameObject plank_prefab;
	public GameObject ice_prefab;
	public int planks_in_stack;
	public int score;
	public int boltCount;

	private List<GameObject> grounds;
	private List<GameObject> ice;
	private Builder builder;
	private BGMover bgMover;
	private SaveGame save;
	private float max_planks;
	public float plank_length;
	public float ground_length;
	private int plank_buffer = 2;

	//===============================================
	//Public Members
	//===============================================

	public void loser() {
		save.updateLastScore (score);
		save.updateBoltCount (boltCount);
		save.updateHighScore (score);
		SceneManager.LoadScene ("Retry");
	}

	public void ground_shift() {
		grounds.Add ((GameObject)(Instantiate (ground_prefab, new_ground_location(grounds[grounds.Count - 1]), Quaternion.identity)));
	}

	public void scored() {
		score++;
	}

	public void boltScore() {
		score++;
		boltCount++;
	}

	public void decrease_stack() {
		planks_in_stack--;
	}

	//===============================================
	//Private Members
	//===============================================

	private float between_space() {
		max_planks = Mathf.Ceil (Random.Range (2.0f, 4.0f));
		planks_in_stack = Mathf.CeilToInt(max_planks + plank_buffer);
		return max_planks * plank_length;
	}

	private Vector3 new_ground_location(GameObject ground) {
		if (grounds.Count >= 4) {
			Destroy (grounds [0]);
			grounds.RemoveAt (0);
		}
		float space = between_space ();
		ice_shift (space, ground);
		return new Vector3 (ground.transform.position.x + space + ground_length/2f, ground.transform.position.y, ground.transform.position.z);
	}

	private void ice_shift(float between_space, GameObject before_ground) {
		if(ice.Count >= 4) {
			Destroy(ice[0]);
			ice.RemoveAt (0);
		}
		float ice_space = Random.Range (1.5f, (between_space - ground_length / 2f - 1.5f));
		Vector3 ice_spot = new Vector3 (before_ground.transform.position.x + ice_space + ground_length/2f, before_ground.transform.position.y + 2.1013f, before_ground.transform.position.z);
		ice.Add ((GameObject)(Instantiate (ice_prefab, ice_spot, Quaternion.identity)));
	}

	//===============================================
	//Game Function
	//===============================================

	// Use this for initialization
	void Start () {
		grounds = new List<GameObject> ();
		grounds.Add (initial_ground);
		ice = new List<GameObject> ();

		plank_length = 5.15f;
		ground_length = initial_ground.GetComponent<Collider> ().bounds.size.x;
		builder = GameObject.FindGameObjectWithTag ("Player").GetComponent<Builder>();
		save = GetComponent<SaveGame> ();


		ground_shift ();

		planks_in_stack = Mathf.CeilToInt(max_planks + plank_buffer);
	}
	
	// Update is called once per frame
	void Update () {
		if(builder.builder_location.y < -7 || planks_in_stack < 0) {
			loser ();
		}
	}
}
