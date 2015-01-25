using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	public GameObject credCube;

	void Start () {
		Camera.main.backgroundColor = Color.black;
		Destroy(GameObject.Find("cursor"));
		credCube.GetComponent<Rotate>().axis = Rotate.Axis.X;
		credCube.GetComponent<Rotate>().rotationDelay = 1f;
	}
}
