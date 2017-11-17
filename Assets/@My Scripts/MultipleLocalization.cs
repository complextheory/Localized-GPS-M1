using UnityEngine;

// Analysis disable CheckNamespace
using NUnit.Framework;
using System;
using System.Collections.Generic;


public class MultipleLocalization : MonoBehaviour {
// Analysis restore CheckNamespace


	// this is the marker object with its own code and more:
	public GameObject prefabMarker;
	// this is the radius of the sphere/planet
	public float R;

	public LoadUserData loadUserData;

	//public XMLManager xmlManager;

	void Awake(){
		//UserListInterface.InitializeList ();

	}

	void Start (){

		InstantiateMarker ();
	}

	void InstantiateMarker(){


		for(int i = 0; i < UserListInterface.GetList().Count; i++){

			// for each connected player add the marker at the LATitude and LONgitude
			//for (int jj = 0; jj < markerLatLon.Length; jj++) {
			GameObject go = GameObject.Instantiate (prefabMarker, new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0)) as GameObject;
			go.transform.parent = transform;

			// now we are setting the values on the marker script from the array of values
			MarkerPositioning markScript = go.GetComponent<MarkerPositioning> ();

			markScript.R = R;
			//markScript.lat = markerLatLon [jj] [0];
			//markScript.lat = countryData.getLatitude (inputManager.inputs[i]);
			markScript.lat = loadUserData.getLatitude (UserListInterface.GetList ()[i]);
			//markScript.lat = loadUserData.getLatitude (tempList[i]);
			//Debug.Log ("City Should be " + loadUserData.getLatitude (UserListInterface.GetList ()[i]));
			Debug.Log ("Latitude = " + markScript.lat);
			//markScript.lon = markerLatLon [jj] [1];
			//markScript.lon = countryData.getLongitude (inputManager.inputs[i]);
			markScript.lon = loadUserData.getLongitude (UserListInterface.GetList ()[i]);
			//markScript.lon = loadUserData.getLongitude (tempList[i]);
			Debug.Log ("Longitude = " + markScript.lon);
			//markScript.col = colors [jj];
			//markScript.col = countryData.getColor (inputManager.inputs[i]);
			markScript.col = loadUserData.getColor (UserListInterface.GetList ()[i]);
			//markScript.col = loadUserData.getColor (tempList[i]);
			//}
			markScript.userIndex = loadUserData.getUserIndex (UserListInterface.GetList ()[i]);

		}
	}
}
