using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {

	void OnColliderEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
