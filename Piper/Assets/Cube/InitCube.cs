using UnityEngine;
using System.Collections;

public class InitCube : MonoBehaviour {

	public Light mainlight;
	public ArrayList walls = new ArrayList();
	
	void Update () {
		mainlight.color = Color.Lerp(mainlight.color, Color.magenta, Time.deltaTime * 0.1f);
	}
}
