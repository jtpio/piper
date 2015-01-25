using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	CardboardHead head;
	LineRenderer lr;
	
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		lr = GetComponent<LineRenderer>();
	}
	
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(head.Gaze, out hit, Mathf.Infinity)){
			lr.SetPosition(1, hit.point);
		}
	}
}
