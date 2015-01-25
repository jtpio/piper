using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Shrink : MonoBehaviour {

	public float shrinkDelay;
	public float shrinkTime;
	private AudioSource shrinkSound;
	
	public float[] sizes = new float[3];
	private float lastSize;

	private IsLookedAt detector;
	private bool isShrinking = false;
	
	void Start() {
		iTween.Init (gameObject);
		float initSize = sizes[Random.Range(0, sizes.Length)];
		lastSize = initSize;
		iTween.ScaleBy(gameObject, iTween.Hash("x", initSize, "y", initSize, "z", initSize, "easeType", "easeOutExpo", "Time", shrinkTime));
		detector = GetComponent<IsLookedAt>();
		shrinkSound = GetComponent<AudioSource>();
	}
	void Update() {
		if (detector.Spotted) {
			renderer.material.color = Color.red;
			if (!isShrinking) {
				isShrinking = true;
				StartCoroutine(RotateBox(shrinkDelay));
			}
		} else {
			isShrinking = false;
			StopCoroutine("RotateBox");
			renderer.material.color = Color.white;
		}
	}
	
	IEnumerator RotateBox (float delay) {
		yield return new WaitForSeconds(delay);
		if (detector.Spotted) { // double check
			float newSize = sizes[0];
			do {
				newSize = sizes[Random.Range(0, sizes.Length)];
			} while (newSize == lastSize);
			lastSize = newSize;
			iTween.ScaleTo(gameObject, iTween.Hash("x", newSize, "y", newSize, "z", newSize, "easeType", "easeOutExpo", "Time", shrinkTime));
		} else {
			isShrinking = false;
		}
	}
	void playSound(){
		if(!shrinkSound.isPlaying)shrinkSound.Play();
	}
	void onRotationComplete() {
		isShrinking = false;
	}
}
