using UnityEngine;
using System.Collections;

public class Idle : MonoBehaviour {

	public Vector3 direction;
	public float amplitude;
	public float speed;

	Vector3 initPosition;
	float phase;

	void Start () {
		if (direction.magnitude == 0) {
			direction = new Vector3(0.0f, 1.0f, 0.0f);
		}
		if (speed == 0) {
			speed = 1;
		}
		initPosition = transform.position;
		phase = Random.Range(0.0f, Mathf.PI);
	}
	
	void Update () {
		transform.position = initPosition + direction * amplitude * Mathf.Sin(speed * Time.time + phase);
	}
}
