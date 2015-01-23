using UnityEngine;
using System.Collections;

public class InitCube : MonoBehaviour {

	public GameObject player;
	public Light light;
	private float size = 5.0f;
	public ArrayList walls = new ArrayList();
	
	void Start () {
		if(player == null)player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		light.color = Color.Lerp(light.color, Color.red, Time.deltaTime * 0.2f);
	}
}
