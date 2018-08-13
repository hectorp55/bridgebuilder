using UnityEngine;
using System.Collections.Generic;

public class Beam : MonoBehaviour {

	//Private Members
	//----------------------------------------------------------------------------------
	private bool hit;
	private bool hit_check_l;
	private bool hit_check_r;
	private Collider plank_collider;
	private Renderer plank_renderer;
	private Vector3 ray_start_l;
	private GameObject[] ices;
	private GameObject closest_ice;
	private float left_pos;
	private float right_pos;
	private RaycastHit hit_info_l;
	private RaycastHit check_hit;
	private GameObject builder;
	private Builder control;

	//----------------------------------------------------------------------------------

	public static float plank_collider_length;
	public static float plank_length;

	//Public Members
	//----------------------------------------------------------------------------------


	//----------------------------------------------------------------------------------
	void Awake () {
		//General computations for use in calculations below
		plank_collider = GetComponent<Collider>();
		plank_renderer = GetComponent<Renderer>();
		plank_collider_length = plank_collider.bounds.size.x;
		plank_length = plank_renderer.bounds.size.x;
		ray_start_l = new Vector3 (transform.position.x - (plank_length/2) + 0.1f, transform.position.y - (plank_length/4), transform.position.z);
	}

	void Start() {
		builder = GameObject.FindWithTag("Player");
		control = builder.GetComponent<Builder> ();
		//Shoots ray to detect if the plank is touching anything
		hit_check_l = Physics.Raycast (ray_start_l, Vector3.right, out hit_info_l, (plank_collider_length));

		if(hit_check_l) {
			if(hit_info_l.collider.CompareTag("Stack") || hit_info_l.collider.CompareTag("Ground")) {
					control.continue_move = true;
			}
		}
	}

	void Update() {
		if(transform.position.y < -7f/*ray_start_r.y -20f*/) {
			control.destroyLastPlank();
		}
	}
}