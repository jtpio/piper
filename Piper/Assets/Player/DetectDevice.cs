using UnityEngine;
using System.Collections;

public class DetectDevice : MonoBehaviour {

	public GameObject[] cursors = new GameObject[2];

	public float offset = 0.25f;

	void Start () {
		if(GetComponent<Cardboard>()){
			Cardboard cb = GetComponent<Cardboard>();
			if(SystemInfo.deviceType == DeviceType.Desktop){
				cb.VRModeEnabled = false;
				//foreach(GameObject cursor in cursors)cursor.SetActive(false);
			}else{
				cb.VRModeEnabled = true;
			}
		}
	}
	void Update(){
		/*cursors[0].GetComponent<RectTransform>().anchorMin = cursors[0].GetComponent<RectTransform>().anchorMax = new Vector2(offset, 0.5f);
		cursors[1].GetComponent<RectTransform>().anchorMin = cursors[1].GetComponent<RectTransform>().anchorMax = new Vector2(1f-offset, 0.5f);*/
	}
}
