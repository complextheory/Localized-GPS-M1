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
		//UserDatabase.inputs = UserListInterface.GetList ();
	}

	//List of Users
	public UserDatabase userDb;



	//Save Function
	public void SaveUsers(){

		
		//UserDatabase.inputs = UserListInterface.GetList ();

		// Open a new XML file
		XmlSerializer serializer = new XmlSerializer (typeof(UserDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/StreamingAssets/XML/item_data.xml", FileMode.Create);
		serializer.Serialize (stream, userDb);
		stream.Close ();
		


		//Debug.Log ("Should Save List. After List = " + UserDatabase.inputs.Count); 
		Debug.Log ("Should Save List. After List = " + userDb.inputs.Count); 
	}

	//Load Function
	public void LoadUsers(){


		XmlSerializer serializer = new XmlSerializer (typeof(UserDatabase));
		FileStream stream = new FileStream (Application.dataPath + "/StreamingAssets/XML/item_data.xml", FileMode.Open);
		userDb = serializer.Deserialize (stream) as UserDatabase;
		stream.Close ();

		//UserListInterface.SetList (UserDatabase.inputs);
		UserListInterface.SetList (userDb.inputs);
	}
}

[System.Serializable]
public class UserDatabase{
	
	//public InputManager inputManager;
	public List <UserInput> inputs = new List<UserInput> ();
	//public static List <UserInput> inputs;

}
