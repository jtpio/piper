using UnityEngine;
using System.Collections;

public class InitCube : MonoBehaviour {

	private GameObject plane;
	public Light light;
	private float size = 5.0f;
	public ArrayList walls = new ArrayList();
	
	void Start () {
		plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Vector3 position = Vector3.up;
		Vector3 rotateAround = Vector3.right;
		float angle = 180f;
		float angle2 = 0f;
		for(int i = 0; i < 3; i++){
			if(i == 1){position = Vector3.right; rotateAround = Vector3.forward; angle = angle2 = 90f;}
			if(i == 2){position = Vector3.forward; rotateAround = Vector3.left;}
			walls.Add(Instantiate(plane, position*size, Quaternion.AngleAxis(angle, rotateAround)));
			walls.Add(Instantiate(plane, position*-size, Quaternion.AngleAxis(-angle2, rotateAround)));
		}
		Destroy(plane);
	}
	
	void Update () {
		light.color = Color.Lerp(light.color, Color.red, Time.deltaTime * 0.2f);
		foreach(GameObject wall in walls)wall.transform.position = wall.transform.position.normalized*Mathf.Abs(size);
		Camera.main.transform.position = Camera.main.transform.position.normalized*Mathf.Abs(size)*1.5f;
		size -= Time.deltaTime * 0.5f;
	}
}
