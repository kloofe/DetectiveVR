using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public GameObject cam;
	public GameObject target;
	private bool moving;
	private bool foundsomething;
	public GameObject inv;
	private bool frozen;

	// Use this for initialization
	void Start () {
		moving = false;
		foundsomething = false;
		frozen = false;
		//target.gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		Vector3 desiredMove = cam.transform.forward;
		desiredMove.y = 0f;


		if (GvrViewer.Instance.Triggered) {
			//if(!inv.GetComponent<InventorySystem>().talking) {

				if ((target.gameObject.GetComponent<Renderer> ().material.color == Color.green) && (foundsomething == false)) {
					if (moving == false) {
						Debug.Log ("I found something");
						foundsomething = true;
					} else {
						moving = false;
					}


				}
				else if((target.gameObject.GetComponent<Renderer> ().material.color == Color.yellow)) {
					moving  = false;
				}
				 else{
					if (moving) {
						moving = false;
					} else {
						moving = true;
						foundsomething = false;
					}
				}
			//}
			//else {
			//	moving = false;
			//}

		}

		// If in a state that the player cannot move: moving is false
		if(frozen) {
			moving = false;
		}
			
		if (moving) {
			transform.Translate (desiredMove * maxSpeed * Time.deltaTime);
		} else {
			gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	public void SetFrozen(bool b) {
		frozen = b;
	}
}
