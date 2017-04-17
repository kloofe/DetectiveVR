using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour {
	public RaycastHit hit;
	public GameObject hitObject1;
	public GameObject hitObject2;
	public GameObject camera;
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
					if (i == 1) {
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

	void changeposition(GameObject hitObject1, GameObject hitObject2){
		Vector3 temp = hitObject1.transform.position;
		hitObject1.transform.position = hitObject2.transform.position;
		hitObject2.transform.position = temp;
	
	}
}
