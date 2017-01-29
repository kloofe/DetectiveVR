using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
	public RaycastHit hit;
	public List<string> collections;
	public GameObject target;
	public GameObject hitObject;
	public Collider hitCollider;
	public GameObject Panel;
	public Text objects;
	public GameObject DialoguePanel;
	public Text Dialogue;
	public string text;
	public GameObject itemButton;
	private int size;
	public string person;

	private GameObject p;

	public bool talking;

	private GameObject cam;
	// Use this for initialization
	void Start ()
	{
		collections = new List<string>();
		Panel.SetActive(false);
		DialoguePanel.SetActive(false);
		text = "";
		cam = target.transform.parent.gameObject;
		talking = false;
		size = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		collectEvidence ();

	}

	void collectEvidence(){
		if (GvrViewer.Instance.Triggered) {
			Raycast targetname = target.GetComponent<Raycast> ();
			string hitTag = targetname.hitTag;
			string hitName = targetname.hitname;
			hitObject = targetname.hitObject;
			hitCollider = targetname.hitCollider;

			if (!talking && hitTag == "evidence") {
				collections.Insert (0, hitName);
				//DestroyImmediate(hitCollider);
				DestroyImmediate (hitObject);
				hitTag = "";
				Debug.Log (hitName + " is added to the InventorySystem");
			} else if (!talking && hitTag == "people"){
				person = targetname.hitname;
				Vector3 tarPos = cam.transform.parent.transform.position;
				Vector3 pos = new Vector3(tarPos.x, tarPos.y, tarPos.z);
				transform.position = pos;
				transform.eulerAngles = cam.transform.eulerAngles;
				text = "";
				 foreach (Transform child in transform) {
				 	child.gameObject.SetActive(true);
				 }
				generateInv ();
				//objects.text = text;
				p = hitObject;
				talking = true;
			}
			else if(talking && hitTag != "evidence" && hitTag != "people") {
				if(hitTag == "Close") {
					talking = false;
					 foreach (Transform child in transform) {
					 	child.gameObject.SetActive(false);
					 }
				}
				else {
					DialoguePanel.SetActive(true);
					Dialogue.text = p.GetComponent<PersonAttributes>().Line(hitTag);
				}
			}
		}

		/*if (target.gameObject.GetComponent<Renderer> ().material.color != Color.blue && !talking) {
			Panel.SetActive (false);
			DialoguePanel.SetActive(false);
		}*/
	}

	void generateInv(){
		if(size < collections.Count) {
			for(int j = size; j < collections.Count;j++)
			{
				GameObject spawned = (GameObject) GameObject.Instantiate(itemButton);
				Vector3 scale = spawned.transform.localScale;
				spawned.transform.SetParent(Panel.transform);
				spawned.transform.localScale = scale;
				spawned.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, 0);
				spawned.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
				spawned.GetComponentInChildren<Text>().text = collections[j];
				spawned.GetComponent<BoxCollider>().enabled = true;
				size++;

			}
		}
		
	}
}

