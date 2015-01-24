using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

	private IsLookedAt detector;
	
	void Start () {
		detector = GetComponent<IsLookedAt>();
	}
	
	void Update () {
		if(detector.Spotted){
			iTween.ScaleBy(gameObject, iTween.Hash("x", .01, "y", .01, "z", .01, "easeType", "easeOutExpo", "Time", 1));
		}
		if(transform.localScale == new Vector3(.01f, .01f, .01f))Destroy(gameObject);
	}
}
