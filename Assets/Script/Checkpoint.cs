using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public static Vector3 respawnPosition;

	// Use this for initialization
	void OnTriggerEnter(Collider) {
		if (other.gameObject.CompareTag("Player")
		Respawn position = transform.position;
	}

}
