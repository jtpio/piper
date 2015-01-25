using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	void Start () {
		Camera.main.backgroundColor = Color.black;
		Destroy(GameObject.Find("cursor"));
	}
}
