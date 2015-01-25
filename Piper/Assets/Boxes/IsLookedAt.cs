using UnityEngine;
using System.Collections;

public class IsLookedAt : MonoBehaviour {
	
	private CardboardHead head;
	private bool spotted = false;
	public float initTime;
	
	void Awake(){
		initTime = 5.0f;
	}
	
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}

	void Update () {

		if (Time.time < initTime) return;
		
		RaycastHit hit;
		if(Physics.Raycast(head.Gaze, out hit, Mathf.Infinity)){
			spotted = (hit.collider.gameObject == gameObject);
		}
	}
	public bool Spotted
	{
		get {
			return spotted;
		}
	}
}
