using UnityEngine;
using System.Collections;

public class DetectDevice : MonoBehaviour {

	public GameObject[] cursors = new GameObject[2];

	void Start () {
		if(GetComponent<Cardboard>()){
			Cardboard cb = GetComponent<Cardboard>();
			if(SystemInfo.deviceType != DeviceType.Desktop){
				cb.VRModeEnabled = false;
				foreach(GameObject cursor in cursors)cursor.SetActive(false);
			}else{
				cb.VRModeEnabled = true;
			}
		}
	}
}
