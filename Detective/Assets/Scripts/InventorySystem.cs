﻿using UnityEngine;
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

	public GameObject p;

	public bool talking;

	private GameObject cam;

	private bool dialogueDisplaying;
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
		dialogueDisplaying = false;

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
			Debug.Log(hitTag);

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
				else if(!dialogueDisplaying) {
					DialoguePanel.SetActive(true);
					Debug.Log("Line:");
					Debug.Log(p.GetComponent<PersonAttribute>().Line(hitTag.ToLower()));
					StartCoroutine(DisplayDialogue(p.GetComponent<PersonAttribute>().Line(hitTag.ToLower()).Trim().Split("\n"[0])));

				}
			}
		}

		/*if (target.gameObject.GetComponent<Renderer> ().material.color != Color.blue && !talking) {
			Panel.SetActive (false);
			DialoguePanel.SetActive(false);
		}*/
	}

	IEnumerator DisplayDialogue(string[] lines) {
		dialogueDisplaying = true;
		Debug.Log("Number of lines: " + lines.Length);
		for(int i = 0; i < lines.Length; i++) {
			Dialogue.text = lines[i];
			yield return new WaitForSeconds(3f);
		}
		DialoguePanel.SetActive(false);
		dialogueDisplaying = false;
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

