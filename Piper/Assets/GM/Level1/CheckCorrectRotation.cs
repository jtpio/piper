﻿using UnityEngine;
using System.Collections;

public class CheckCorrectRotation : MonoBehaviour {

	public GameObject[] cubes = new GameObject[4];
	private bool flag;
	private AudioSource win;
	
	void Start(){
		win = GetComponent<AudioSource>();
		flag = false;
	}
	
	void Update () {
		foreach(GameObject cube in cubes)if(cube.GetComponent<Rotate>().rot != 0){flag = false; break;}else{flag = true;};
		if(flag){
			Debug.Log("YOU WIN!");
			if(!win.isPlaying)win.Play();
			Application.LoadLevel("Level2");
		}
	}
}