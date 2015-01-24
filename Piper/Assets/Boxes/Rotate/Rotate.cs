using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	private IsLookedAt detector;
	
	void Start() {
		detector = GetComponent<IsLookedAt>();
	}
	void Update() {
		renderer.material.color = detector.Spotted ? Color.yellow : Color.white;
	}
}
