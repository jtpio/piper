using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	CardboardHead head;
	
	void Update () {
		head = Camera.main.GetComponent<StereoController>().Head;
	
		RaycastHit hit;
		
		if(collider.Raycast(head.Gaze, out hit, Mathf.Infinity) && Cardboard.SDK.CardboardTriggered){
			AutoFade.LoadLevel(1, 3, 2, Color.black);
		}
		
	}
}
