using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Button>().onClick.AddListener(() => { 
			AutoFade.LoadLevel("Level1", 3, 1, Color.black);
		}); 
	}
}
