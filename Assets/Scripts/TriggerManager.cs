using UnityEngine;
using System.Collections.Generic;

public class TriggerManager : MonoBehaviour {
	public List<GameObject> collidedObjects = new List<GameObject>();

	/*
	void Start() {
		//
	}

	void Update() {
		//
	}
	*/

	private void OnTriggerEnter(Collider other) {
		collidedObjects.Add(other.gameObject);
	}

	private void OnTriggerExit(Collider other) {
		collidedObjects.Remove(other.gameObject);
	}
}
