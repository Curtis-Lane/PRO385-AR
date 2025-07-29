using UnityEngine;
using System.Collections.Generic;

public class BackupBlockDetector : MonoBehaviour {
	private bool available = true;
	private JengaBlock currentBlock;
	private List<Collider> colliders = new();

	void Start() {
		//
	}

	void Update() {
		if(available) {
			(int, float) closestData = (-1, float.PositiveInfinity);
			for(int i = 0; i < colliders.Count; i++) {
				float currentDistance = Vector3.Distance(colliders[i].ClosestPoint(transform.parent.position), transform.parent.position);
				if(currentDistance < closestData.Item2) {
					closestData.Item1 = i;
					closestData.Item2 = currentDistance;
				}
			}
			if(closestData.Item1 != -1) {
				currentBlock = colliders[closestData.Item1].gameObject.GetComponent<JengaBlock>();
				currentBlock.MarkHovered();
			} else {
				currentBlock = null;
			}
		}

		//colliders.Clear();
	}

	//private void OnTriggerStay(Collider other) {
	//	if(other.gameObject.GetComponent<JengaBlock>() != null) {
	//		colliders.Add(other);
	//	}
	//}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetComponent<JengaBlock>() != null) {
			colliders.Add(other);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.GetComponent<JengaBlock>() != null) {
			colliders.Remove(other);
		}
	}

	public void Lock() {
		if(currentBlock != null) {
			currentBlock.Lock(transform.parent);
			available = false;
		}
	}

	public void Unlock() {
		if(currentBlock != null) {
			available = true;
			currentBlock.Unlock();
		}
	}

	public void Send() {
		if(available) {
			Lock();
		} else {
			Unlock();
		}
	}

	public void ClearColliders() {
		colliders.Clear();
	}
}
