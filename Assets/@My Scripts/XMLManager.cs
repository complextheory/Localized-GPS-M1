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

	//List<UserInput> saveList = new List<UserInput>();


	void Awake(){

		ins = this;
		UserDatabase.inputs = UserListInterface.GetList ();
	}

	//List of Users
	public static UserDatabase userDb;


	//Save Function
	public static void SaveUsers(){
		
		// Open a new XML file
		XmlSerializer serializer = new XmlSerializer (typeof(UserDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/StreamingAssets/XML/item_data.xml", FileMode.Create);
		serializer.Serialize (stream, userDb);
		stream.Close ();
	}

	//Load Function
	public static void LoadUsers(){
		XmlSerializer serializer = new XmlSerializer (typeof(UserDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/StreamingAssets/XML/item_data.xml", FileMode.Open);
		userDb = serializer.Deserialize (stream) as UserDatabase;
		stream.Close ();
	}
}

[System.Serializable]
public class UserDatabase{
	
	//public InputManager inputManager;
	public static List <UserInput> inputs = new List<UserInput> ();


}
