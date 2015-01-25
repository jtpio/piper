using UnityEngine;
using System.Collections;

public class CheckTextRemoved : MonoBehaviour {

	
	public ParticleSystem ps;
	public Transform cubeMap;
	public Transform piper;
	public Transform player;
	public Transform cursor;
	public Transform finalPosPiper;
	
	bool won = false;

	void OnLevelWasLoaded(int level) {
		GameState.won = false;
		GameState.finalWin = false;
	}

	void Update () {
		
		if (won) return;
		
		if (!GameObject.Find("ExplodingBox")){
			won = true;
			StartCoroutine(PiperRoutine());
		}
	}
	
	IEnumerator PiperRoutine () {
		yield return new WaitForSeconds(3);
		Instantiate(ps, new Vector3(0, 0, 0), Quaternion.identity);
		cubeMap.gameObject.SetActive(false);
		player.GetComponent<RepositionPlayer>().Reposition();
		Destroy(cursor.gameObject);
		Destroy(GameObject.Find("LaserBeam"));

		yield return new WaitForSeconds(10);
		Destroy(piper.GetComponent<Wandering>());
		GameState.finalWin = true;
		iTween.MoveTo(piper.gameObject, iTween.Hash("position", finalPosPiper, "looktarget", player , "easeType", "easeInOutQuart", "Time", 2));
		yield return new WaitForSeconds(10);

		AudioControl piperAudio = piper.GetComponent<AudioControl>();
		while (piperAudio.isPlaying) yield return null;

		AutoFade.LoadLevel("Level4", 3, 1, Color.black);
	}
	
}
