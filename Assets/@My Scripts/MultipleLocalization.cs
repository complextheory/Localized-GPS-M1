using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Analysis disable CheckNamespace
public class MultipleLocalization : MonoBehaviour {
// Analysis restore CheckNamespace
	

	// number of markers and their latitute and longitude
	//public Vector2[] markerLatLon;
	// this will be the colors of the markers
	//public Color[] colors;
	// this is the marker object with its own code and more:
	public GameObject prefabMarker;
	// this is the radii o the sphere/planet
	public float R;

	//public GameObject dataLoader;

	public LoadCountryData countryData;




	void Start () 
	{
		
//		LoadCountryData countryData = dataLoader.GetComponent<LoadCountryData> ();


		//foreach (UserEntry user in XMLManager.ins.userDb.list) {


			// for each connected player add the marker at the LATitude and LONgitude
			//for (int jj = 0; jj < markerLatLon.Length; jj++) {
				GameObject go = GameObject.Instantiate (prefabMarker, new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0)) as GameObject;
				go.transform.parent = transform;

				// now we are setting the values on the marker script from the array of values
				MarkerPositioning markScript = go.GetComponent<MarkerPositioning> ();

				markScript.R = R;
				//markScript.lat = markerLatLon [jj] [0];
				markScript.lat = countryData.getLatitude ();
			Debug.Log ("Latitude = " + markScript.lat);
			//markScript.lon = markerLatLon [jj] [1];
				markScript.lon = countryData.getLongitude ();
			Debug.Log ("Longitude = " + markScript.lon);
				//markScript.col = colors [jj];
				markScript.col = countryData.getColor ();
			//}


		//}
	}



}
