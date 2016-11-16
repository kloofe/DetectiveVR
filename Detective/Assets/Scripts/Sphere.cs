using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
	public RaycastHit hit;
	public Camera Mcam;
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		ObjectMotherClass distance = new ObjectMotherClass ();
		string hitname = distance.Distance (gameObject,Mcam,target);
		if ((hitname == "Sphere")&&(GvrViewer.Instance.Triggered)) {
			Debug.Log ("it is a Sphere");
		}
	}
}