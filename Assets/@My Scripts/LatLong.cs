using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatLong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static LatLong FromVector3(Vector3 position, float sphereRadius){

		//Theta
		float lat = (float)Mathf.Acos (position.y / sphereRadius);
		//Phi
		float lon = (float)Mathf.Atan (position.x / position.z);

		return new LatLong ();
	}
}
