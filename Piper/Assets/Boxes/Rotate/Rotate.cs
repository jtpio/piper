using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	private IsLookedAt detector;
	
	void Start() {
		detector = GetComponent<IsLookedAt>();
	}
	void Update() {
		if (detector.Spotted) {
			renderer.material.color = Color.yellow;
			iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack"));
		} else {
			renderer.material.color = Color.white;
		}
	}
}
