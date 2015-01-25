using UnityEngine;
using System.Collections;
using System.Linq;

public class CheckCorrectSizes : MonoBehaviour {

	public Transform player;
	public float playerWinRotationTime;
	public Transform goodBigFinalPos;
	public Transform goodLFinalPos;
	public Transform goodRFinalPos;
	
	private bool levelWon = false;
	Transform goodBig = null;
	Transform goodL = null;
	Transform goodR = null;
	
	void Start () {
	}
	
	void LateUpdate () {

		if (levelWon) return; 

		goodBig = null;
		goodL = null;
		goodR = null;

		foreach (Transform child in transform) {
			if (child.GetComponent<Shrink>().CurrentSize == 1) {
				switch (child.name) {
				case "ShrinkingBox2":
					goodBig = child;
					break;
				case "ShrinkingBoxL":
					goodL = child;
					break;
				case "ShrinkingBoxR":
					goodR = child;
					break;
				}
			}
		}

		if (goodBig != null && goodL != null && goodR != null) {
			levelWon = true;
			StartCoroutine(WinLevel());
		} else {
			goodBig = null;
			goodL = null;
			goodR = null;
		}
	}

	IEnumerator WinLevel () {
		GameObject.Find("Point light").light.color = new Color(93.0f / 255.0f, 1.0f, 0.0f);
		goodBig.GetComponent<Shrink>().ShrinkToDoor();
		goodL.GetComponent<Shrink>().ShrinkToDoor();
		goodR.GetComponent<Shrink>().ShrinkToDoor();
		player.GetComponent<RepositionPlayer>().Reposition();		
		
		yield return new WaitForSeconds(1);

		Transform[] toDisable = {goodBig, goodL, goodR};
		foreach (Transform t in transform) {
			if (toDisable.Contains(t)) {
				t.renderer.material.color = Color.white;
				MonoBehaviour[] scripts = t.gameObject.GetComponents<MonoBehaviour>();
				foreach(MonoBehaviour script in scripts) {
					script.enabled = false;
				}
			} else {
				t.GetComponent<Shrink>().ShrinkToZero();
			}
		}
		
		iTween.MoveTo(goodBig.gameObject, iTween.Hash("position", goodBigFinalPos, "looktarget", goodBigFinalPos.transform.position + goodBigFinalPos.forward , "easeType", "easeInOutQuart", "Time", 2));
		iTween.MoveTo(goodL.gameObject, iTween.Hash("position", goodLFinalPos, "looktarget", goodLFinalPos.transform.position + goodLFinalPos.forward , "easeType", "easeInOutQuart", "Time", 2));
		iTween.MoveTo(goodR.gameObject, iTween.Hash("position", goodRFinalPos, "looktarget", goodRFinalPos.transform.position +  goodRFinalPos.forward, "easeType", "easeInOutQuart", "Time", 2));

		StartCoroutine(PlayerRotationFinished(playerWinRotationTime + 2.0f));
	}

	IEnumerator PlayerRotationFinished (float delay) {
		yield return new WaitForSeconds(delay);
		AutoFade.LoadLevel("Level3", 3, 1, Color.black);
	}
}
