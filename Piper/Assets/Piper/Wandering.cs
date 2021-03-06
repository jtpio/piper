﻿using UnityEngine;
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
		float yOffset = yAmplitude * (Mathf.Cos(Mathf.Sin(Mathf.Cos(0.5f*Time.time)+Time.time))+Mathf.Sin(Mathf.Cos(Time.time+Mathf.Sin(Mathf.Cos(0.3f*Time.time))))-0.5f);
		transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
		if(target != null) {
			Vector3 truePos = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.position = truePos + (transform.position - truePos).normalized * orbitDistance;
			float variation = Mathf.Min(Mathf.Max(Mathf.Abs(Mathf.Cos(Time.time) * Mathf.Sin(Time.time + 0.5f)) - 0.25f, 0.2f), 0.4f) - 0.15f;
			transform.RotateAround(truePos, Vector3.up, 10f * variation * orbitDegreesPerSec * Time.deltaTime);
		}
	}

	void Update () {
		
	}

	void LateUpdate () {
		Orbit();
		Vector3 relativePos = target.position - transform.position;
		var rotation = Quaternion.LookRotation(relativePos);
		rotation.eulerAngles = new Vector3(rotation.eulerAngles.x + 10*Mathf.Clamp01(Mathf.Sin(0.5f*Time.time)*4-2), 
										rotation.eulerAngles.y + 30*Mathf.Clamp01(Mathf.Cos(Time.time)*8-6), 
										rotation.eulerAngles.z);
		transform.rotation = rotation;
	}
}
