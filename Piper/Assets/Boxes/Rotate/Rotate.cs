using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	private IsLookedAt detector;
	private Renderer renderer;

	void Start() {
		detector = GetComponent<IsLookedAt>();
		renderer = GetComponent<Renderer>();
	}
	
	void Update() {
		Debug.Log(detector.Spotted);
		renderer.material.color = detector.Spotted ? Color.yellow : Color.white;
	}
}
