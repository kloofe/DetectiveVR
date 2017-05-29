using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour {
	public RaycastHit hit;
	public GameObject hitObject1;
	public GameObject hitObject2;
	public GameObject camera;
	public GameObject puzzleObj;
	public List<GameObject> puzzles;
	public List<string> puzzlepieces;
	public int i;
	public string puz1 = "puz1";
	public string puz2 = "puz2";
	public string puz3 = "puz3";
	public string puz4 = "puz4";
	public string puz5 = "puz5";
	public string puz6 = "puz6";
	public string puz7 = "puz7";
	public string puz8 = "puz8";

	private int puzzleCount;
	private bool playing;
	// Use this for initialization
	void Start () {
		i = 1;
		playing = false;
		puzzleCount = 0;
		puzzleObj = puzzles [0];
		if (puzzleCount == 0) {
			puz7 = null;
			puz8 = null;
			puzzlepieces.Add (puz1);
			puzzlepieces.Add (puz2);
			puzzlepieces.Add (puz3);
			puzzlepieces.Add (puz4);
			puzzlepieces.Add (puz5);
			puzzlepieces.Add (puz6);
		}
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
						i = 2;
					} else if (i == 2) {
						hitObject2 = hit.collider.gameObject;
						Debug.Log (hitObject2.name);
						changeposition (hitObject1, hitObject2);
						i = 1;
					} 

					if(IsCorrect()) {
						Debug.Log ("it is correct!");
						puzzleCount++;
						puzzlenum ();
						if(puzzleCount < 3) {
							puzzleObj.SetActive(false);
							puzzleObj = puzzles[puzzleCount];
							puzzleObj.SetActive(true);
						}
						else {
							puzzleObj.SetActive(false);
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

	bool IsCorrect() {
		for (int j = 0 ; j < puzzlepieces.Capacity - 1; j++){
			print ("Capacity:" + puzzlepieces.Capacity);
			print ("j" + j);
			Debug.Log(string.Compare(puzzlepieces[j],puzzlepieces[j+1]));
			if (string.Compare(puzzlepieces[j],puzzlepieces[j+1]) > 0){ 
				return false;
			}
		}
		return true;
	}

	void changeposition(GameObject hitObject1, GameObject hitObject2){
		Vector3 temp = hitObject1.transform.position;
		hitObject1.transform.position = hitObject2.transform.position;
		hitObject2.transform.position = temp;
		int tempindex = puzzlepieces.IndexOf (hitObject2.tag);
		puzzlepieces [puzzlepieces.IndexOf (hitObject1.tag)] = hitObject2.tag;
		puzzlepieces [tempindex] = hitObject1.tag;
	}

	void puzzlenum(){

		if (puzzleCount == 1) {
			puzzlepieces.Add (puz1);
			puzzlepieces.Add (puz2);
			puzzlepieces.Add (puz3);
			puzzlepieces.Add (puz4);
			puzzlepieces.Add (puz5);
			puzzlepieces.Add (puz6);
			puzzlepieces.Add (puz7);
			puzzlepieces.Add (puz8);
		}

	}
}
