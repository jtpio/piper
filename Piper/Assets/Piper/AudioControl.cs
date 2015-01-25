using UnityEngine;
using System.Collections;
using System.Linq;

public class AudioControl : MonoBehaviour {

	AudioSource[] sources;
	AudioSource goodJob;

	public bool isPlaying;

	void Start () {
		StartCoroutine(startSound());
		sources = GetComponents<AudioSource>();

		goodJob = sources[2];
	}
	
	void Update () {
		if(Time.time < 5) return;

		isPlaying = sources.Any(item => item.isPlaying);
		if(isPlaying) return;
		
		if (GameState.won) {
			if (goodJob != null) {
				goodJob.Play();
				goodJob = null;
			}
		} else {
			foreach (AudioSource aud in sources) {
				if (GameState.finalWin) {
					aud.pitch = 0.6f;
				} else {
					aud.pitch = Mathf.Lerp(aud.pitch, 1.3f, Time.deltaTime*0.025f);
				}
			}
			sources[(2 + Random.Range(1, sources.Length)) % sources.Length].Play();
		}
	}
	
	IEnumerator startSound(){
		yield return new WaitForSeconds(5);
	}
}
