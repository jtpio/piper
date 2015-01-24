using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	public float rotationDelay;
	private AudioSource audio;

	private IsLookedAt detector;
	private bool isRotating = false;
	
	void Start() {
		iTween.Init (gameObject);
		detector = GetComponent<IsLookedAt>();
		audio = GetComponent<AudioSource>();
	}
	void Update() {
		if (detector.Spotted) {
			renderer.material.color = Color.yellow;
			if (!isRotating) {
				isRotating = true;
				StartCoroutine(RotateBox(rotationDelay));
			}
		} else {
			isRotating = false;
			StopCoroutine("RotateBox");
			renderer.material.color = Color.white;
		}
	}

	IEnumerator RotateBox (float delay) {
		yield return new WaitForSeconds(delay);
		if (detector.Spotted) { // double check
			iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "oncomplete", "onRotationComplete", "onstart", "playSound"));
		} else {
			isRotating = false;
		}
	}
	void playSound(){
		if(!audio.isPlaying)audio.Play();
	}
	void onRotationComplete() {
		isRotating = false;
	}
}
