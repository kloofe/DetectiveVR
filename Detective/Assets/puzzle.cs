using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour {
	public RaycastHit hit;
	public GameObject hitObject1;
	public GameObject hitObject2;
	public GameObject camera;
	public GameObject puzzleObj;
	public int i;

	private bool playing;
	// Use this for initialization
	void Start () {
		i = 1;
		playing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playing) {
			Ray myRay = new Ray (transform.position, camera.transform.forward);
			Debug.DrawRay (transform.position, camera.transform.forward * 10, Color.green);
			if (Physics.Raycast (myRay, out hit, 12f, 1 << 14)) {
				Debug.Log ("hit");
				if (GvrViewer.Instance.Triggered) {
					if(hit.collider.tag == "close") {
						StopPuzzle();
					}
					else if (i == 1) {
						hitObject1 = hit.collider.gameObject;
						Debug.Log (hitObject1.name);
						if (i == 1) {
							print (i);
						}
						i = 2;
					} else if (i == 2) {
						hitObject2 = hit.collider.gameObject;
						Debug.Log (hitObject2.name);
						changeposition (hitObject1, hitObject2);
						if (i == 2) {
							print (i);
						}
						i = 1;
					} 
				}
			}
		}
	}

	public void StartPuzzle() {
		playing = true;
		Vector3 tarPos = camera.transform.parent.transform.position;
		Vector3 pos = new Vector3(tarPos.x, tarPos.y + .8f, tarPos.z);
		puzzleObj.transform.position = pos + camera.transform.forward * 2;
		Vector3 angles = camera.transform.eulerAngles;
		// 0 = 180; 90 = 270; 180 = 0; 270 = 90;
		puzzleObj.transform.eulerAngles = new Vector3(0f, 180 + angles.y, 0f);
		GetComponent<PlayerController>().SetFrozen(true);
	}

	public void StopPuzzle() {
		playing = false;
		puzzleObj.SetActive(false);
		GetComponent<PlayerController>().SetFrozen(false);
	}

	void changeposition(GameObject hitObject1, GameObject hitObject2){
		Vector3 temp = hitObject1.transform.position;
		hitObject1.transform.position = hitObject2.transform.position;
		hitObject2.transform.position = temp;
	
	}
}
