using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairwayswitch : MonoBehaviour {
	public RaycastHit hit;
	public GameObject hitObject;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject camera;
	public GameObject switchObj;
	public GameObject realswitch;
	public float objscale;
	public float y1;
	public float y2;
	public float y3;
	public int i;

	private bool playing;
	// Use this for initialization
	void Start () {
		i = 1;
		objscale = switchObj.transform.lossyScale.y/4;
		y1 = switchObj.transform.position.y;
		y2 = y1 + objscale;
		y3 = y1 - objscale;
		playing = false;
	}

	// Update is called once per frame
	void Update () {
		Ray myRay = new Ray (transform.position, camera.transform.forward);
		Debug.DrawRay (transform.position, camera.transform.forward * 40, Color.green);
		if (Physics.Raycast (myRay, out hit, 12f, 1 << 17)) {
			Debug.Log ("obj1.transform.position.y" + obj1.transform.position.y);
			Debug.Log ("obj2.transform.position.y" + obj2.transform.position.y);
			Debug.Log ("obj3.transform.position.y" + obj3.transform.position.y);
			Debug.Log ("obj4.transform.position.y" + obj4.transform.position.y);
			Debug.Log ("obj5.transform.position.y" + obj5.transform.position.y);
			if (GvrViewer.Instance.Triggered) {
				if(hit.collider.tag == "close") {
					StopPuzzle();
				}
				else {
					if (winningstate() == true) {
						Debug.Log ("Winning");
						Destroy (switchObj);
						Destroy (obj1);
						Destroy (obj2);
						Destroy (obj3);
						Destroy (obj4);
						realswitch.SetActive(true);
					} else {
						hitObject = hit.collider.gameObject;
						Debug.Log (hitObject.name);
						if (hitObject.transform.localPosition.y == 0) {
							hitObject.transform.position = new Vector3(hitObject.transform.position.x,y3,hitObject.transform.position.z);
						} else if (hitObject.transform.localPosition.y == 0.25) {
							hitObject.transform.position = new Vector3(hitObject.transform.position.x,y2,hitObject.transform.position.z);
						} else {
							hitObject.transform.position = new Vector3(hitObject.transform.position.x,y1,hitObject.transform.position.z);
						}
					}
				}
			}
		}
	}


	public void StartPuzzle() {
		playing = true;
		Vector3 tarPos = camera.transform.parent.transform.position;
		Vector3 pos = new Vector3(tarPos.x, tarPos.y + .8f, tarPos.z);
		switchObj.transform.position = pos + camera.transform.forward * 2;
		Vector3 angles = camera.transform.eulerAngles;
		// 0 = 180; 90 = 270; 180 = 0; 270 = 90;
		switchObj.transform.eulerAngles = new Vector3(0f, 180 + angles.y, 0f);
		GetComponent<PlayerController>().SetFrozen(true);
	}

	public void StopPuzzle() {
		playing = false;
		switchObj.SetActive(false);
		GetComponent<PlayerController>().SetFrozen(false);
	}


	public bool winningstate(){
		if (obj1.transform.position.y == y1 && obj2.transform.position.y == y3 && obj3.transform.position.y == y1 && obj4.transform.position.y == y2 && obj5.transform.position.y == y1) {
			return true;
		} else {
			return false;
		}
	}
}
