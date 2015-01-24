using UnityEngine;
using System.Collections;

public class Wandering : MonoBehaviour {

	public Transform target;

	public float yAmplitude;
	public float orbitDistance;
	public float orbitDegreesPerSec;
	
	void Start () {
	
	}

	void Orbit()
	{
		float yOffset = Mathf.Sin(Time.time) * yAmplitude;
		transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
		if(target != null) {
			Vector3 truePos = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.position = truePos + (transform.position - truePos).normalized * orbitDistance;
			transform.RotateAround(truePos, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
		}
	}

	void Update () {

	}

	void LateUpdate () {
		Orbit();
		Vector3 relativePos = target.position - transform.position;
		var rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;
	}
}
