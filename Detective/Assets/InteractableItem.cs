using UnityEngine;
using System.Collections;

public class InteractableItem : MonoBehaviour {
	public RaycastHit hit;
	public Camera Mcam;
	public GameObject target;

	public string description;
	public string name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ObjectMotherClass distance = new ObjectMotherClass ();
		string hitname = distance.Distance (gameObject,Mcam,target);
		if ((hitname == name)&&(GvrViewer.Instance.Triggered)) {
			Debug.Log("I am a: " + name + " and my description is: " + description);
		}	
	}
}
