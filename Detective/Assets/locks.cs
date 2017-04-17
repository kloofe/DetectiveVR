using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locks : MonoBehaviour {
	public GameObject lock1;
	public GameObject lock2;
	public GameObject lock3;
	public GameObject lock4;
	public RaycastHit hit;
	public Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray myRay = new Ray (transform.position, camera.transform.forward);
		Debug.DrawRay (transform.position, camera.transform.forward * 10, Color.red);
		if (Physics.Raycast (myRay, out hit, 12f, 1 << 15)) {
			Debug.Log (hit.collider.name);
			if (GvrViewer.Instance.Triggered) {
				hit.collider.gameObject.transform.Rotate(Vector3.up, 36);
			} 
		}
		if (Rotatelock () == true) {
			Debug.Log ("chestOpened!");	
		}
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
