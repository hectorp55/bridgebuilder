using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour {
	//Public Members
	//----------------------------------------------------------------------------------

	public GameObject bigger_plank;
	public AudioClip power_wrench;

	//Private Members
	//----------------------------------------------------------------------------------
	private GameObject main_holder;
	private Game_Manager main_script;
	private Builder control;
	private Vector3 parents_location;
	private Vector3 original_location;
	private Vector3 translation;
	private Vector3 offset;
	
	//----------------------------------------------------------------------------------
	//Member Functions	

	void Awake() {
		original_location = transform.position;	
		translation = new Vector3 (0f, 0.01f, 0f);
		offset = new Vector3 (0f, 0.151f, 0f); //Previously determined offset between ice and beam
	}

	// Use this for initialization
	void Start () {
		main_holder = GameObject.FindWithTag ("Manager");
		main_script = main_holder.GetComponent<Game_Manager> ();
		control = GameObject.FindWithTag ("Player").GetComponent<Builder> ();

		parents_location = new Vector3 (transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > original_location.y+0.2f) {
			translation = translation * (-1);
		}
		else if (transform.position.y < original_location.y-0.1f) {
			translation = translation * (-1);
		}
		transform.Translate (translation);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			main_script.boltScore();
			control.drop_bigger_plank(parents_location + offset);
			Destroy(transform.parent.gameObject);
		}
	}
}
