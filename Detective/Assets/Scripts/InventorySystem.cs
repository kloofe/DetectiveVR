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
	public string text;
	// Use this for initialization
	void Start ()
	{
		collections = new List<string>();
		Panel.SetActive(false);
		text = "";

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

			if (hitTag == "evidence") {
				collections.Insert (0, hitName);
				//DestroyImmediate(hitCollider);
				DestroyImmediate (hitObject);
				hitTag = "";
				Debug.Log (hitName + " is added to the InventorySystem");
			} else if (hitTag == "people"){
				text = "";
				Panel.SetActive (true);
				Print ();
				objects.text = text;
				Debug.Log ("printing finished");
			}
		}

		if (target.gameObject.GetComponent<Renderer> ().material.color != Color.blue) {
			Panel.SetActive (false);
		}
	}

	void Print(){
		for(int j = 0; j < collections.Count;j++)
		{
			Debug.Log ("collection[" + j + "]" + "=" + collections [j]);
			text += collections[j]+"\t";
			if ((j + 1) % 3 == 0) {
				text += "\n\n\n";
			
			}

		}
		
	}
}

