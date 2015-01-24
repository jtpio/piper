using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Shrink : MonoBehaviour {

	public Vector3 initScale;
	public float shrinkDelay;
	public float shrinkTime;
	private AudioSource shrinkSound;
	
	public float[] sizes = new float[3];
	private int currentSize = 0;

	private IsLookedAt detector;
	private bool isShrinking = false;
	
	void Start() {
		iTween.Init (gameObject);
		currentSize = Random.Range(0, sizes.Length - 2); // only the first 4 to avoid an instant win
		float initSize = sizes[currentSize];
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * initSize, "y",  initScale.y * initSize, "z", initScale.z * initSize, "easeType", "easeOutExpo", "Time", shrinkTime));
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
			
			currentSize = ++currentSize%sizes.Length;
			newSize = sizes[currentSize];
			
			Debug.Log ("currentSize: " + currentSize);
			iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * newSize, "y", initScale.y * newSize, "z", initScale.z * newSize, "easeType", "easeOutExpo", "Time", shrinkTime));
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

	public int CurrentSize {
		get {
			return currentSize;
		}
	}
}
