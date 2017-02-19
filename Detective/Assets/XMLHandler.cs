using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class XMLHandler : MonoBehaviour {

	private XmlDocument xmlDoc;
	private string filepath;

	public Dictionary<string, Dictionary<string, string>> lines;

	// Use this for initialization
	void Start () {
		lines = new Dictionary<string, Dictionary<string,string>>();
		LoadXML();
		//AttachDescriptions();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadXML() {
		/*
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
				//lines [item.Attributes["name"].Value] = item.InnerText;
			}

		}	*/
		TextAsset textAsset = (TextAsset)Resources.Load("itemDialogues", typeof(TextAsset));
		//filepath = Application.streamingAssetsPath + @"/XML/itemDialogues.xml";
		//Debug.Log(filepath);
		//if (File.Exists (filepath)) 
		Debug.Log(textAsset);
		//{
			//Debug.Log("Foun XML file");
			xmlDoc = new XmlDocument ();
			try {
				xmlDoc.LoadXml ( textAsset.text );
			} catch (FileNotFoundException) {
				Debug.Log ("The file for loading the XML was not found");
				return;
			}


			XmlNodeList nodes = xmlDoc.GetElementsByTagName("person");

			foreach(XmlNode person in nodes) {
				foreach (XmlNode item in person.ChildNodes) {
					if(!lines.ContainsKey(person.Attributes["name"].Value)) {
						lines [person.Attributes["name"].Value] = new Dictionary<string, string>();	

					}
					lines [person.Attributes["name"].Value][item.Attributes["type"].Value] = item.InnerText;
				}
			}

		//}	
	}

	void AttachDescriptions() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Interactable");
		foreach(GameObject o in objs) {
			InteractableItem script = o.GetComponent<InteractableItem>();
			//script.description = items[script.name];
		}
	}
}
