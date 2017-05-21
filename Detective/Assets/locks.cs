using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locks : MonoBehaviour {
	public GameObject lock1;
	public GameObject lock2;
	public GameObject lock3;
	public GameObject lock4;
	public GameObject lockObj;
	public RaycastHit hit;
	public Camera camera;
	private bool playing;
	// Use this for initialization
	void Start () {
		playing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playing) {
			Ray myRay = new Ray (transform.position, camera.transform.forward);
			Debug.DrawRay (transform.position, camera.transform.forward * 10, Color.red);
			if (Physics.Raycast (myRay, out hit, 12f, 1 << 15)) {
				Debug.Log (hit.collider.name);
				if (GvrViewer.Instance.Triggered) {
					if(hit.collider.tag == "close") {
						StopLockPuzzle();
					}
					else {
						hit.collider.gameObject.transform.Rotate(Vector3.up, 36);
					}
				}
			}
			if (Rotatelock ()) {
				playing = false;
				GetComponent<PlayerController>().SetFrozen(false);
				Debug.Log ("chestOpened!");	
			}
		}
	}

	public void StartLockPuzzle() {
		playing = true;
		Vector3 tarPos = camera.transform.parent.transform.position;
		Vector3 pos = new Vector3(tarPos.x, tarPos.y + .8f, tarPos.z);
		lockObj.transform.position = pos + camera.transform.forward * 2;
		Vector3 angles = camera.transform.eulerAngles;
		// 0 = 180; 90 = 270; 180 = 0; 270 = 90;
		lockObj.transform.eulerAngles = new Vector3(90f, 180 + angles.y, 0f);
		GetComponent<PlayerController>().SetFrozen(true);
	}

	public void StopLockPuzzle() {
		playing = false;
		lockObj.SetActive(false);
		GetComponent<PlayerController>().SetFrozen(false);
	}

	bool Rotatelock(){
		int rot1 = ((int)lock1.transform.eulerAngles.x)%360;
		Debug.Log ("Lock 1 rotation: " + lock1.transform.eulerAngles.x);
		int rot2 = ((int)lock2.transform.eulerAngles.x)%360;
		Debug.Log ("Lock2  rotation: " + lock2.transform.eulerAngles.x);
		int rot3 = ((int)lock3.transform.eulerAngles.x)%360;
		Debug.Log ("Lock 3 rotation: " + lock3.transform.eulerAngles.x);
		int rot4 = ((int)lock4.transform.eulerAngles.x)%360;
		Debug.Log ("Lock 4 rotation: " + lock4.transform.eulerAngles.x);
		if((rot1 == 342) && (rot2 == 18) && (rot3 == 306) && (rot4 == 90)){
			Debug.Log ("chestOpened!");
			return true;
		}
		return false;
	}
}
