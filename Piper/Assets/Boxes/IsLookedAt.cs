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
		spotted = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
	}

	public bool Spotted
	{
		get {
			return spotted;
		}
	}
}
