using UnityEngine;
using System.Collections.Generic;

public class FakeRaycastSender : MonoBehaviour {
	[SerializeField]
	private TriggerManager trigger;

	private JengaBlock currentBlock;
	private bool available = true;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//
	}

	// Update is called once per frame
	void Update() {
		if(available) {
			List<JengaBlock> blocks = new List<JengaBlock>();
			foreach(GameObject go in trigger.collidedObjects) {
				if(go.TryGetComponent(out JengaBlock block)) {
					blocks.Add(block);
				}
			}

			//
		}
	}

	public void Lock() {
		if(currentBlock != null) {
			currentBlock.Lock(transform);
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
}
