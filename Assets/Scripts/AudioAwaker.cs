using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAwaker : MonoBehaviour {
	public GameObject persistentPrefab;

	// Use this for initialization
	void Start () {
		GameObject persistantObject = GameObject.FindWithTag("Persistant");

		if (!persistantObject) {
			Instantiate(persistentPrefab, Vector3.one, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
