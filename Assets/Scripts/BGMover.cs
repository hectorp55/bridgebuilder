using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour {

	public List<GameObject> bgPrefabs;

	public List<GameObject> bgs;
	private int bgSize;

	public void shiftBG() {
		if (bgs.Count >= 15) {
			Destroy (bgs [0]);
			bgs.RemoveAt (0);
		}
		int prefabIndex = Random.Range (0, bgPrefabs.Count);
		Vector3 bgSpot = new Vector3 (bgs [bgs.Count - 1].transform.position.x + bgSize, 
			bgs [bgs.Count - 1].transform.position.y, 
			bgs [bgs.Count - 1].transform.position.z);
		bgs.Add ((GameObject)(Instantiate (bgs[prefabIndex], bgSpot, Quaternion.identity)));
	}


	// Use this for initialization
	void Start () {
		bgSize = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
