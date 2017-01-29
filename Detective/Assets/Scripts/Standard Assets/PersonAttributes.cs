using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonAttributes : MonoBehaviour
{
	public string Name;
	public GameObject target;
	public bool talking;
	public GameObject canvas;
	public Dictionary<string, Dictionary<string, string>> lines;
	public GameObject gameManager;
	public string person;
	public Raycast targetname;
	private XMLHandler xml;
	// Use this for initialization
	void Start()
	{
		xml = gameManager.GetComponent<XMLHandler> ();
		lines = xml.lines;
		InventorySystem people = canvas.GetComponent<InventorySystem> ();
		talking = people.talking;	
		targetname = target.GetComponent<Raycast> ();	
	}

	public string Line (string itemName)
	{
		return(lines [Name] [itemName]);
	}
}

