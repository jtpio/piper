using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Shrink : MonoBehaviour {

	public Vector3 initScale;
	public float shrinkDelay;
	public float shrinkTime;
	private AudioSource shrinkSound;
	
	public float[] sizes = new float[4];
	private int currentSize;

	private IsLookedAt detector;
	private bool isShrinking = false;
	
	void Start() {
		iTween.Init (gameObject);
		currentSize = Random.Range(0, sizes.Length);
		Debug.Log(currentSize);
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

	public void ShrinkToDoor () {
		iTween.Stop(gameObject);
		currentSize = 1;
		float initSize = sizes[currentSize];
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * initSize, "y",  initScale.y * initSize, "z", initScale.z * initSize, "easeType", "easeOutExpo", "Time", shrinkTime));
	}

	public void ShrinkToZero () {
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * 0.2f, "y",  initScale.y * 0.2f, "z", initScale.z * 0.2f, "easeType", "easeOutExpo", "Time", shrinkTime));
	}

	IEnumerator RotateBox (float delay) {
		yield return new WaitForSeconds(delay);
		if (detector.Spotted) { // double check
			float newSize = sizes[(currentSize+1)%sizes.Length];
			
			Debug.Log ("currentSize: " + currentSize);
			iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * newSize, "y", initScale.y * newSize, "z", initScale.z * newSize, "easeType", "easeOutExpo", "Time", shrinkTime));
			currentSize = ++currentSize%sizes.Length;
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
