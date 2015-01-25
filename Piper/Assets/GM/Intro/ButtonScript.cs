using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	CardboardHead head;
	IsLookedAt isLookedAt;

	bool focused = false;

	void Start () {
		isLookedAt = GetComponent<IsLookedAt>();
		isLookedAt.initTime = 0.0f;
	}

	void Update () {
		head = Camera.main.GetComponent<StereoController>().Head;
	
		RaycastHit hit;
		
		if (isLookedAt.Spotted) {
			StartCoroutine(StartGame(0.5f));
		} else {
			StopCoroutine("StartGame");
		}
		
	}

	IEnumerator StartGame (float delay) {
		yield return new WaitForSeconds(delay);
		if (isLookedAt.Spotted) {
			AutoFade.LoadLevel(1, 3, 2, Color.black);
		}
	}
}
