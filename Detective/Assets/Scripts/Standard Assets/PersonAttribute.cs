using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonAttribute : MonoBehaviour
{
	public string Name;
	public Dictionary<string, Dictionary<string, string>> lines;
	public GameObject gameManager;
	public string person;
	private XMLHandler xml;
	// Use this for initialization
	void Start()
	{
		xml = gameManager.GetComponent<XMLHandler> ();
		lines = xml.lines;
	}

	public string Line (string itemName)
	{
		Debug.Log (xml.lines[Name]);
		return xml.lines[Name][itemName];
	}
}

