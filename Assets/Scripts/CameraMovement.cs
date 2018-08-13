using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Builder builder;
	private Vector3 builder_pos;
	private Vector3 camera_pos;

	// Use this for initialization
	void Start () {
		builder = GameObject.FindGameObjectWithTag ("Player").GetComponent<Builder>();
	}
	
	// Update is called once per frame
	void Update () {
		builder_pos = builder.builder_location;

		camera_pos = transform.position;

		//Constantly adjust x to the x position of the builder
		transform.position = new Vector3 (builder_pos.x, camera_pos.y, camera_pos.z);
	}
}
