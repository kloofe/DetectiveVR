using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class XMLHandler : MonoBehaviour {

	private XmlDocument xmlDoc;
	private string filepath;

	public Dictionary<string, string> items;

	// Use this for initialization
	void Start () {
		items = new Dictionary<string, string>();
		LoadXML();
		//AttachDescriptions();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadXML() {
		filepath = Application.streamingAssetsPath + @"/XML/ItemText.xml";
		Debug.Log(filepath);
		if (File.Exists (filepath)) 
		{
			//Debug.Log("Foun XML file");
			xmlDoc = new XmlDocument ();
			try {
				xmlDoc.Load (filepath);
			} catch (FileNotFoundException) {
				Debug.Log ("The file for loading the XML was not found");
				return;
			}


			XmlNodeList nodes = xmlDoc.GetElementsByTagName("Item");

			foreach(XmlNode item in nodes) {
				items[item.Attributes["name"].Value] = item.InnerText;
			}

		}	
	}

	void AttachDescriptions() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("evidence");
		foreach(GameObject o in objs) {
			ObjectMotherClass script = o.GetComponent<ObjectMotherClass>();
			script.description = items[script.name];
		}
	}
}
