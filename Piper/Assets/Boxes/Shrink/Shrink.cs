using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

	public float shrinkSpeed;
	public float scaleDelay;
	public int[] sizes = new int[3];

	private IsLookedAt detector;
	private bool lastSpotted = false;
	private bool isScaling = false;

	void Start () {
		iTween.Init (gameObject);
		detector = GetComponent<IsLookedAt>();
	}
	
	void Update () {
		if(detector.Spotted){
			if (!isScaling) {
				isScaling = true;
				StartCoroutine(ScaleBox(scaleDelay));
			}
			renderer.material.color = Color.red;
		} else {
			isScaling = true;
			StopCoroutine("ScaleBox");
			renderer.material.color = Color.white;
		}
	}

	IEnumerator ScaleBox (float delay) {
		yield return new WaitForSeconds(delay);
		if (detector.Spotted) { // double check
			int scale = Random.Range(0, sizes.Length);
			iTween.ScaleBy(gameObject, iTween.Hash("x", scale, "y", scale, "z", scale, "easeType", "easeOutExpo", "Time", 1.3));
		} else {
			isScaling = false;
		}
	}

	void onRotationComplete() {
		isScaling = false;
	}
}
