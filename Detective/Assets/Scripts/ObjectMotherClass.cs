using UnityEngine;
using System.Collections;

public class ObjectMotherClass {

	public string Distance(GameObject gameobject, Camera cam, GameObject target){
		var gameObZ = gameobject.transform.position.z;
		var gameObX = gameobject.transform.position.x;
		var camZ = cam.transform.position.z;
		var camX = cam.transform.position.x;
		float X = gameObX - camX;
		float Z = gameObZ - camZ;
		float distSquare = Z * Z + X * X;
		float dist = Mathf.Sqrt(distSquare);
		if (dist <= 10) {
			target.gameObject.SetActive (true);
		} else {
			target.gameObject.SetActive (false);
		}	
			
		Raycast targetname = target.GetComponent<Raycast> ();
		string hitname = targetname.hitname;
		return hitname;
	}
}