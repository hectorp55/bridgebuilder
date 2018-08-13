using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {
	//Private Members
	//----------------------------------------------------------------------------------
	private Builder control;
	private GameObject builder;
	private Vector3 raycast_start;
	private Vector3 offset;
	private Collider coll;
	private float off_set_x;
	private float height;
	private bool spot;

	public GameObject rayspot;
	
	//Public Static Members
	//----------------------------------------------------------------------------------
	
	//Public Members
	//----------------------------------------------------------------------------------
	
	//Functions
	//----------------------------------------------------------------------------------
	void Awake() {
		coll = GetComponent<Collider> ();
		off_set_x = coll.bounds.size.x*3;
		height = coll.bounds.size.y;
		offset = new Vector3 (off_set_x, height/2, 0f);
	}
	
	void Start () {
		builder = GameObject.FindWithTag("Player");
		control = builder.GetComponent<Builder> ();
	}

	void OnTriggerExit(Collider other) {
		raycast_start = transform.position + offset;
		//Instantiate (rayspot, raycast_start, Quaternion.identity);
		spot = Physics.Raycast (raycast_start, Vector3.down, height);
		if (!spot) {
			control.fallPlayer();
		}

	}
}
