using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
	public RaycastHit hit;
	public GameObject cam;
	public string hitname;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray myRay = new Ray(transform.position, cam.transform.forward);
		Debug.DrawRay (transform.position,cam.transform.forward*10,Color.black);
		if (gameObject.activeSelf == true) {
			if (Physics.Raycast (myRay, out hit, 10f, 1 << 10)) {
				GetComponent<Renderer> ().material.color = Color.green;
				hitname = hit.collider.name;

			} else {
				GetComponent<Renderer> ().material.color = Color.red;
			}
		}

	}
}
