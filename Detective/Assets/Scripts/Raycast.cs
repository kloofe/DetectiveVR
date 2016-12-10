using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
	public RaycastHit hit;
	public GameObject cam;
	public string hitname;
	public string hitTag;
	public GameObject hitObject;
	public Collider hitCollider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray myRay = new Ray(transform.position, cam.transform.forward);
		Debug.DrawRay (transform.position,cam.transform.forward*10,Color.black);
		if (gameObject.activeSelf == true) {
			if (Physics.Raycast (myRay, out hit, 12f, 1 << 10)) {
				GetComponent<Renderer> ().material.color = Color.green;
				hitname = hit.collider.name;
				hitTag = hit.collider.tag;
				hitObject = hit.collider.gameObject;
				hitCollider = hit.collider;
			}else if(Physics.Raycast (myRay, out hit, 12f, 1 << 11)){
				GetComponent<Renderer> ().material.color = Color.blue;
				hitTag = hit.collider.tag;
			}
			else {
				hitTag = "";
				GetComponent<Renderer> ().material.color = Color.red;
			}
		}

		Objecthit ();
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
