using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	private CardboardHead head;
	private Vector3 startingPosition;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.green : Color.red;
		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			// Triggered when it is looked at, do something maybe, will se later
		}
	}
}
