using UnityEngine;
using System.Collections;

public class DetectDevice : MonoBehaviour {

	void Start () {
		if(GetComponent<Cardboard>()){
			Cardboard cb = GetComponent<Cardboard>();
			if(SystemInfo.deviceType == DeviceType.Desktop){
				cb.VRModeEnabled = false;
			}else{
				cb.VRModeEnabled = true;
			}
		}
	}
}
