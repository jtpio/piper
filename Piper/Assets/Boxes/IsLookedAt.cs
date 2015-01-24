using UnityEngine;
using System.Collections;

public class IsLookedAt : MonoBehaviour {
	
	private CardboardHead head;
	private bool spotted = false;
	
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}

	void Update () {
		RaycastHit hit;
		spotted = (Physics.Raycast(head.Gaze, out hit, Mathf.Infinity)==gameObject);
	}

	public bool Spotted
	{
		get {
			return spotted;
		}
	}
}
