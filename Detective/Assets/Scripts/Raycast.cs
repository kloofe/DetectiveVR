using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {
	public RaycastHit hit;
	public GameObject cam;
	public string hitname;
	public string hitTag;
	public GameObject hitObject;
	public Collider hitCollider;
	// Use this for initialization
	void Start () {
		if(cam == null) {
			cam = GameObject.FindGameObjectsWithTag("MainCamera")[0];
		}	
	}
	
	// Update is called once per frame
	void Update () {
		Ray myRay = new Ray(transform.position, cam.transform.forward);
		Debug.DrawRay (transform.position,cam.transform.forward*10,Color.black);
		if (gameObject.activeSelf == true) {
			if (Physics.Raycast (myRay, out hit, 12f, 1 << 10)) {
				ChangeColor(Color.green);
				hitname = hit.collider.name;
				hitTag = hit.collider.tag;
				if(hitTag == "Untagged") {
					hitTag = hit.collider.gameObject.transform.parent.gameObject.tag;
					hitObject = hit.collider.gameObject.transform.parent.gameObject;
				}
				else {
					hitObject = hit.collider.gameObject;
				}
				hitCollider = hit.collider;
			}else if(Physics.Raycast (myRay, out hit, 12f, 1 << 11)){
				ChangeColor(Color.blue);
				hitTag = hit.collider.tag;
				hitObject = hit.collider.gameObject;
			}
			else if(Physics.Raycast(myRay, out hit, 12f, 1 << 13)) {
				ChangeColor(Color.green);
				//hit.collider.gameObject.GetComponent<
			}
			else if(Physics.Raycast(myRay, out hit, 12f, 1 << 16)) {
				ChangeColor(Color.green);
				hitTag = hit.collider.tag;
				hitObject = hit.collider.gameObject;
				if(GvrViewer.Instance.Triggered) {
					transform.parent.gameObject.transform.parent.GetComponent<locks>().StartLockPuzzle();
				}
			}	
			else {
				ChangeColor(Color.red);
				hitTag = "";
			}
			if(Physics.Raycast (myRay, out hit, 12f, 1 << 5)){
				ChangeColor(Color.yellow);
				hitTag = hit.collider.gameObject.GetComponentInChildren<Text>().text;
				hitObject = hit.collider.gameObject;
			}	
		}

		//Objecthit ();
	}

	private void ChangeColor(Color c) {
		if(GetComponent<Renderer>() == null) {
			foreach(Renderer r in GetComponentsInChildren<Renderer>()) {
				r.material.color = c;
			}
		}
		else {
			GetComponent<Renderer> ().material.color = c;	
		}
	}

	public void Objecthit(){

		if((GvrViewer.Instance.Triggered)&&(gameObject.GetComponent<Renderer> ().material.color == Color.green)){
			if (hitname == "Sphere") {
				Debug.Log ("it is a Sphere");
			}

			if (hitname == "Cube") {
				Debug.Log ("it is a Cube");
			}		

			if (hitname == "Cylinder") {
				Debug.Log ("it is a Cylinder");
			}

			if (hitname == "Vase") {
				Debug.Log ("it is a Vase");
			}

			if (hitname == "Lamp") {
				Debug.Log ("it is a Lamp");
			}

			if (hitname == "Bench") {
				Debug.Log ("it is a Bench");
			}


		}

	}

}
