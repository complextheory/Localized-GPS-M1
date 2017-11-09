using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatitudeLong : MonoBehaviour {

	Ray camRay;
	RaycastHit floorHit;

	Vector3 playerToMouse;

	Quaternion newRotation;
	int planetLayer;


	float camRayLength = 100;

	public GameObject pointer;

	void Awake(){
		planetLayer = LayerMask.GetMask ("Planet");
		//		floorHit = new RaycastHit;

	}
	
	// Update is called once per frame
	void Update () {
//		Turning ();
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit))
			if (hit.collider != null) {
				//FromVector3 ();
				Debug.Log ("Should Instantiate " + pointer + "@ " + hit.transform.position);
				Instantiate (pointer, hit.transform.position, hit.transform.rotation);
			}
				//hit.collider.enabled = false;
			}
		}

	public static LatLong FromVector3(Vector3 position, float sphereRadius){

		//Theta
		float lat = (float)Mathf.Acos (position.y / sphereRadius);
		//Phi
		float lon = (float)Mathf.Atan (position.x / position.z);

		return new LatLong ();
	}


	//void Turning{
//	void Turning(){
//		camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//		/// RAY FLOOR HIT NEVER INITALIZED TO ANYTHING??
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, planetLayer))
//		{
//			playerToMouse = floorHit.point - transform.position;
//			playerToMouse.y = 0f;
//
//			newRotation = Quaternion.LookRotation (playerToMouse);
//
//
//		}
//	}
}
