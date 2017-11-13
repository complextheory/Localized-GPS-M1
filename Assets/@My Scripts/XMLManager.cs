using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;					//Basic XML attributes
using System.Xml.Serialization;		//Access XMLSerializer
using System.IO;					//For File Management
	

// Analysis disable CheckNamespace
public class XMLManager : MonoBehaviour {
// Analysis restore CheckNamespace

	public static XMLManager ins;

	void Awake(){

		ins = this;
	}

	//List of Users
	//public UserDatabase userDb;
}

//[System.Serializable]
//public class UserEntry{
//
//	public string userName;
//
//	public string userCity;
//
//	public Color markerColor;
//
//	//public float latitude, longitude;
//}

//[System.Serializable]
//public class UserDatabase{
//
//	public List <UserEntry> list = new List<UserEntry> ();
//}
