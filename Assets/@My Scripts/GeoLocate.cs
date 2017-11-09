using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoLocate : MonoBehaviour {

	Ray camRay;
	RaycastHit floorHit;

	Vector3 playerToMouse;

	Quaternion newRotation;
	int planetLayer;

	public GameObject infoObject;

	float camRayLength = 100;

	public GameObject pointer;


	public Transform myobject; // marker object
	float myradius = 5; // globe ball radius
	float mylatitude = 0; // lat
	float mylongitude = 0; // long


	// Use this for initialization
	void Start () {
		planetLayer = LayerMask.GetMask ("Planet");

		// convert lat/long to radians
		mylatitude = Mathf.PI  * mylatitude / 180;
		mylongitude = Mathf.PI  * mylongitude / 180;

		// adjust position by radians	
		mylatitude -= 1.570795765134f; // subtract 90 degrees (in radians)

		// and switch z and y (since z is forward)
		float xPos = (myradius) * Mathf.Sin(mylatitude) * Mathf.Cos(mylongitude);
		float zPos = (myradius) * Mathf.Sin(mylatitude) * Mathf.Sin(mylongitude);
		float yPos = (myradius) * Mathf.Cos(mylatitude); 


		// move marker to position
		myobject.position = new Vector3(xPos,yPos,zPos);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			if (hit.collider != null) {
				//Vector3 currentMousePoint = PolarToCartesian (CartesianToPolar (Input.mousePosition));
				Vector3 currentMousePoint = PolarToCartesian(CartesianToPolar (hit.point));
				//LatLong (currentMousePoint, 25f);
				//Debug.Log ("LatLong =  " + LatLong(currentMousePoint, 25f));
				Debug.Log ("LatLong =   " + mylatitude + ", " + mylongitude);
				//Instantiate (pointer,)
				//Instantiate (pointer, hit.transform.position, hit.transform.rotation);
				Instantiate (pointer, transform.position, transform.rotation);
			}
			//hit.collider.enabled = false;
		}
	}

	Vector2 CartesianToPolar(Vector3 point)
	{
		Vector2 polar;

		//calc longitude
		polar.y = Mathf.Atan2(point.x,point.z);

		//this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
		//float xzLen = Vector2 (point.x, point.z).magnitude;

		Vector2 vec2 = new Vector2 (point.x, point.z);
		float xzLen = vec2.magnitude;

		//atan2 does the magic
		polar.x = Mathf.Atan2(-point.y, xzLen);

		//convert to deg
		polar *= Mathf.Rad2Deg;

		return polar;
	}


//	Vector3 PolarToCartesian(Vector2 polar)
	Vector3 PolarToCartesian(Vector2 polar)
	{

		//an origin vector, representing lat,lon of 0,0. 

		Vector3 origin = new Vector3 (0,0,1);

		//build a quaternion using euler angles for lat,lon
		Quaternion rotation = Quaternion.Euler(polar.x,polar.y,0);

		//transform our reference vector by the rotation. Easy-peasy!
		Vector3 point = rotation * origin;

		Debug.Log ("Point = " + point);
		//Instantiate (infoObject, point, rotation);
		return point;
	}

	public static Vector2 LatLong(Vector3 position, float sphereRadius){

		//Theta
		float lat = (float)Mathf.Acos (position.y / sphereRadius);
		//Phi
		float lon = (float)Mathf.Atan (position.x / position.z);

		Vector2 latLong = new Vector2 (lat, lon);


		return latLong;
	}
}
