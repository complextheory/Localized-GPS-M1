using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLocation : MonoBehaviour {


	public Collider coll;
	Vector3 hitPoint;

	Vector2 latLon;

	// Use this for initialization
	void Start () {
		
		coll = GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			RaycastHit hit;
			if (coll.Raycast (ray, out hit, 100.0F)) {
				//transform.position = ray.GetPoint(100.0F);
				hitPoint = hit.point;
				latLon = CartesianToPolar (hitPoint);

				//latLon = LatLong (hitPoint, 6371393f);
				Debug.Log ("LatLong = " + latLon);
			}
		}
	}



	Vector2 CartesianToPolar(Vector3 point)
	{
		Vector2 polar;

		//calc longitude

//		polar.y = Mathf.Acos(point.z / point.x);
		polar.y = Mathf.Atan2 (point.x, point.z);
		Debug.Log ("y = " + polar.y);

		//this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
		//float xzLen = Vector2 (point.x, point.z).magnitude;

//		Vector2 vec2 = new Vector2 (point.x, point.z);
//		float xzLen = vec2.magnitude;
		float xzLen = new Vector2(point.x,point.z).magnitude; 

		//atan2 does the magic
		//polar.x = Mathf.Atan2(-point.y, xzLen);
		polar.x = Mathf.Atan2(point.y, xzLen);


		//convert to deg
		polar *= Mathf.Rad2Deg;

		//Debug.Log ("y = " + polar.y + 10);

		return polar;
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
