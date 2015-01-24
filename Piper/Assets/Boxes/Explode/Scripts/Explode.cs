using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	private IsLookedAt detector;
	public GameObject ptcl;
	public bool exploded;
	
	void Start () {
		detector = GetComponent<IsLookedAt>();
		exploded = false;
	}
	
	void Update () {
		if(detector.Spotted && !exploded){
			iTween.ScaleBy(gameObject, iTween.Hash("x", .01, "y", .01, "z", .01, "easeType", "EaseInOutBack", "Time", 1));
			if(ptcl != null)Instantiate(ptcl, transform.position, Quaternion.identity);
			exploded = true;
		}
		if(transform.localScale == new Vector3(.01f, .01f, .01f))Destroy(gameObject);
	}
}
