using UnityEngine;
using System.Collections;

public class Idle : MonoBehaviour {

	public float amplitude;

	Vector3 initPosition;
	float phase;

	void Start () {
		initPosition = transform.position;
		phase = Random.Range(0.0f, Mathf.PI);
	}
	
	void Update () {
		transform.position = initPosition + new Vector3(0.0f, amplitude * Mathf.Sin(Time.time + phase), 0.0f);
	}
}
