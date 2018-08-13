using UnityEngine;
using System.Collections.Generic;

public class Plank : MonoBehaviour {
	
	//Private Members
	//----------------------------------------------------------------------------------
	private bool hit;
	private bool hit_check_l;
	private bool hit_check_r;
	private Collider plank_collider;
	private Renderer plank_renderer;
	private Rigidbody plank_rigid;
	private float plank_height;
	private Vector3 ray_start_r;
	private Vector3 ray_start_l;
	private GameObject[] ices;
	private GameObject closest_ice;
	private float left_pos;
	private float right_pos;
	private RaycastHit hit_info_l;
	private RaycastHit hit_info_r;
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
		plank_rigid = GetComponent<Rigidbody> ();
		plank_collider_length = plank_collider.bounds.size.x;
		plank_height = plank_renderer.bounds.size.y;
		plank_length = plank_renderer.bounds.size.x;
		ray_start_r = new Vector3 (transform.position.x - (plank_length/2) + plank_collider_length - 0.1f, transform.position.y - (plank_height/2), transform.position.z);
		ray_start_l = new Vector3 (transform.position.x - (plank_length/2) + 0.1f, transform.position.y - (plank_height/2), transform.position.z);
	}

	void Start() {
		builder = GameObject.FindWithTag("Player");
		control = builder.GetComponent<Builder> ();
		//Shoots ray to detect if the plank is touching anything
		hit = Physics.Raycast (ray_start_r, Vector3.left, out check_hit, (plank_collider_length - 0.3f));
		if (!hit) { //If plank is not touching anything the plank will fall
			plank_rigid.isKinematic = false;
		}
		if(hit && check_hit.collider.tag == "Ice") {
			hit = false;
			plank_rigid.isKinematic = false;
			Destroy(check_hit.collider.gameObject);
		}
		if (hit) {
			//audio.PlayOneShot(hammer);
			hit_check_l = Physics.Raycast (ray_start_l, Vector3.right, out hit_info_l, (plank_collider_length - 0.1f));
			hit_check_r = Physics.Raycast (ray_start_r, Vector3.left, out hit_info_r, (plank_collider_length - 0.1f));
			if(hit_check_l) {
				if(hit_info_l.collider.CompareTag("Ice")) {
					Destroy(hit_info_l.collider.gameObject);
				}
				if(hit_info_l.collider.CompareTag("Ground")) {
					if(control != null) {
						control.continue_move = true;
					}
				}
			}
			else if(hit_check_r) {
				if(hit_info_r.collider.CompareTag("Ice")) {
					Destroy(hit_info_r.collider.gameObject);
				}
			}
		}
	}

	void Update() {
		if(transform.position.y < -7f/*ray_start_r.y -20f*/) {
			control.destroyLastPlank();
		}
	}
}