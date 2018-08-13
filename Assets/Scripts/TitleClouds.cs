using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleClouds : MonoBehaviour {

	private Vector3 pos;
	private Vector3 reset_pos;

	// Use this for initialization
	void Start () {
		reset_pos = new Vector3 (-18, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		transform.position = pos + new Vector3(Time.deltaTime, 0f, 0f);
		if(pos.x > 18) {
			transform.position = reset_pos;
		}
	}
}
