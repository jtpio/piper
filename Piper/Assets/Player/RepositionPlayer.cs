using UnityEngine;
using System.Collections;

public class RepositionPlayer : MonoBehaviour {

	public float rotationTime;

	Quaternion initQuaternionPlayer;

	void Start () {
		initQuaternionPlayer = transform.rotation;
	}

	void Update () {

	}

	public void Reposition () {
		GetComponent<MouseLook>().enabled = false;
		GetComponent<Cardboard>().enabled = false;
		
		iTween.RotateTo(gameObject, iTween.Hash("rotation", initQuaternionPlayer.eulerAngles, "easeType", "easeInOutQuart", "Time", rotationTime));
	}
}

