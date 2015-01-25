using UnityEngine;
using System.Collections;

public class CheckCorrectRotation : MonoBehaviour {

	public GameObject[] cubes = new GameObject[4];
	private bool flag;
	private AudioSource win;

	private bool won = false;
	
	void Start(){
		win = GetComponent<AudioSource>();
		flag = false;
	}
	
	void Update () {
		if (won) return;

		foreach(GameObject cube in cubes) {
			if(cube.GetComponent<Rotate>().rot != 0) { 
				flag = false; break;
			} else { 
				flag = true;
			}
		}

		if(flag){
			won = true;
			Debug.Log("YOU WIN!");
			StartCoroutine(WinRoutine());
		}
	}

	IEnumerator WinRoutine () {
		yield return new WaitForSeconds(0);
		if(!win.isPlaying) win.Play();
		AutoFade.LoadLevel("Level2", 3, 1, Color.black);
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("box")) {
			if(obj.name == "RotatingBox") {
				obj.GetComponent<Rotate>().enabled = false;
			}
		}
	}
}
