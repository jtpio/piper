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

		yield return new WaitForSeconds(10);
		Destroy(piper.GetComponent<Wandering>());
		iTween.MoveTo(piper.gameObject, iTween.Hash("position", finalPosPiper, "looktarget", player , "easeType", "easeInOutQuart", "Time", 2));
	}

	//Trigger two: move piper in front of player
	
	//Trigger three: fade to black
	
}
