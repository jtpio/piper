using UnityEngine;
using System.Collections;

public class InitCube : MonoBehaviour {

	public Light light;
	public ArrayList walls = new ArrayList();
	
	void Update () {
		light.color = Color.Lerp(light.color, Color.magenta, Time.deltaTime * 0.1f);
	}
}
