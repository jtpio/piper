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
	private GameObject cubeMap;

	private IsLookedAt detector;
	private bool isShrinking = false;
	
	void Start() {
		cubeMap = GameObject.Find("Cube_Map");
		iTween.Init (gameObject);
		int[] rnd = {0, 2, 3};
		currentSize = rnd[Random.Range(0, rnd.Length)];
		Debug.Log(currentSize);
		float initSize = sizes[currentSize];
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * initSize, "y",  initScale.y * initSize, "z", initScale.z * initSize, "easeType", "easeOutExpo", "Time", shrinkTime));
		detector = GetComponent<IsLookedAt>();
		shrinkSound = GetComponent<AudioSource>();
		GetComponent<ParticleSystem>().Play();
		GetComponent<ParticleSystem>().enableEmission = (currentSize == 1);
	}
	void Update() {
		if (detector.Spotted) {
			renderer.material.color = Color.red;
			if (!isShrinking) {
				isShrinking = true;
				StartCoroutine(ShrinkBox(shrinkDelay));
			}
		} else {
			isShrinking = false;
			StopCoroutine("ShrinkBox");
			renderer.material.color = Color.white;
		}
	}

	public void ShrinkToDoor () {
		iTween.Stop(gameObject);
		currentSize = 1;
		float initSize = sizes[currentSize];
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * initSize, "y",  initScale.y * initSize, "z", initScale.z * initSize, "easeType", "easeOutExpo", "Time", shrinkTime, "onstart", "playSound"));
	}

	public void ShrinkToZero () {
		iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * 0.2f, "y",  initScale.y * 0.2f, "z", initScale.z * 0.2f, "easeType", "easeOutExpo", "Time", shrinkTime));
	}

	IEnumerator ShrinkBox (float delay) {
		yield return new WaitForSeconds(delay);
		if (detector.Spotted) { // double check
			float newSize = sizes[(currentSize+1)%sizes.Length];
			
			Debug.Log ("currentSize: " + currentSize);
			iTween.ScaleTo(gameObject, iTween.Hash("x", initScale.x * newSize, "y", initScale.y * newSize, "z", initScale.z * newSize, "easeType", "easeOutExpo", "Time", shrinkTime, "onstart", "playSound"));
			currentSize = ++currentSize%sizes.Length;
			GetComponent<ParticleSystem>().enableEmission = (currentSize == 1);
			if(Time.time > 5)iTween.PunchPosition(cubeMap, iTween.Hash("amount", cubeMap.transform.position + 5 * Vector3.up, "time", 0.5f));
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
