using UnityEngine;
using System.Collections;

public class CheckCorrectSizes : MonoBehaviour {

	void Start () {
	}
	
	void LateUpdate () {

		Transform goodBig = null;
		Transform goodL = null;
		Transform goodR = null;

		foreach (Transform child in transform) {
			switch (child.name) {
			case "ShrinkingBox2":
				if (child.GetComponent<Shrink>().CurrentSize == 3) {
					goodBig = child;
				}
				break;
			case "ShrinkingBoxL":
				if (child.GetComponent<Shrink>().CurrentSize == 1) {
					goodL = child;
				}
				break;
			case "ShrinkingBoxR":
				if (child.GetComponent<Shrink>().CurrentSize == 1) {
					goodR = child;
				}
				break;
			}
		}

		if (goodBig != null && goodL != null && goodR != null) {
			Debug.Log ("WIIIIIIIN");
			AutoFade.LoadLevel("Level3", 3, 1, Color.black);
		}

	}
}
