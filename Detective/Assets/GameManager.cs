using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject spawnPt;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player.transform.position = spawnPt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
