using UnityEngine;
using System.Collections;

public class AudioControl : MonoBehaviour {

	
	
	void Start () {
		StartCoroutine(startSound());	
	}
	
	void Update () {
		if(Time.time > 5){
			audio.pitch = Mathf.Lerp(audio.pitch, 1.3f, Time.deltaTime*0.025f);
		}
	}
	
	IEnumerator startSound(){
		yield return new WaitForSeconds(5);
		audio.Play();
	}
}
