using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Rotate : MonoBehaviour {

	public float rotationDelay;
	private AudioSource rotationSound;
	
	public int rot;
	public enum Axis {X, Y, Z};
	public Axis axis;
	
	private IsLookedAt detector;
	private bool isRotating = false;
	
	private GameObject cubeMap;
	
	private Vector3 startPos;
	
	void Start() {
		cubeMap = GameObject.Find("Cube_Map");
		gameObject.tag = "box";
		startPos = transform.position;
		transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f));
		rotationDelay = 0.25f;
		iTween.Init (gameObject);
		axis = (Axis)Random.Range(0, 3);
		rot = 1+Random.Range(0, 3);
		iTween.MoveTo(gameObject, iTween.Hash("x", startPos.x, "y", startPos.y, "z", startPos.z, "easeType", "easeInExpo", "Time", 3, "oncomplete", "randomRotation"));
		detector = GetComponent<IsLookedAt>();
		rotationSound = GetComponent<AudioSource>();
	}
	void randomRotation(){
		iTween.RotateBy(gameObject, iTween.Hash(axis.ToString(), rot*.25, "easeType", "easeInOutBack", "Time", 1, "onstart", "playSound", "delay", Random.Range(0f, 2f)));
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
			iTween.RotateBy(gameObject, iTween.Hash(axis.ToString(), .25, "Time", 0.5f, "easeType", "easeInOutBack", "oncomplete", "onRotationComplete", "onstart", "playSound"));
			if(Time.time > 5 && cubeMap != null)iTween.RotateBy(cubeMap, iTween.Hash(axis.ToString(), -.25, "Time", 0.5f, "easeType", "easeInOutBack"));
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
