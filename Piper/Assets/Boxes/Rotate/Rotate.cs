using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	public float rotationDelay;
	private AudioSource rotationSound;
	
	public int rot;
	public enum Axis {X = 0, Y = 1, Z = 2};
	public Axis axis;
	
	private IsLookedAt detector;
	private bool isRotating = false;
	
	void Start() {
		iTween.Init (gameObject);
		axis = (Axis)Random.Range(0, 3);
		rot = 1+Random.Range(0, 3);
		iTween.RotateBy(gameObject, iTween.Hash(axis.ToString(), rot*.25, "easeType", "easeInOutBack", "Time", 1, "onstart", "playSound", "delay", .2));
		detector = GetComponent<IsLookedAt>();
		rotationSound = GetComponent<AudioSource>();
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
			iTween.RotateBy(gameObject, iTween.Hash(axis.ToString(), .25, "easeType", "easeInOutBack", "oncomplete", "onRotationComplete", "onstart", "playSound"));
		} else {
			isRotating = false;
		}
	}
	void playSound(){
		if(!rotationSound.isPlaying)rotationSound.Play();
	}
	void onRotationComplete() {
		isRotating = false;
		rot = ++rot%4;
	}
}
