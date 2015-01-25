using UnityEngine;
using System.Collections;

public class moveWall : MonoBehaviour {

	public Material mat;
	
	void Update () {
		mat.SetTextureOffset("_MainTex", new Vector2(Time.time/10f, Time.time/10f));
		Debug.Log (Time.time);
	}
}
