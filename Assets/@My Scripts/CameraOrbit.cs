using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

	private Transform cameraTransform;
	private Transform pivotTransform;

	private Vector3 localRotation;
	private float cameraDistance = 5f;

	public float mouseSensitivity = 4f;
	public float scrollSensitivity = 2f;
	public float orbitDampening = 10f;
	public float scrollDampening = 6f;

	public bool cameraDisabled = false;

	// Use this for initialization
	void Start () {
		cameraTransform = this.transform;
		pivotTransform = this.transform.parent;
	}


	bool down = false;
	
	// LateUpdate is called after update so that it is the last thing to happen in the scene
	void LateUpdate () {

		if (Input.GetKeyDown (KeyCode.LeftShift))
			cameraDisabled = !cameraDisabled;

		if(!cameraDisabled){

//			if (Input.GetMouseButtonDown (0)) {
//				down = true;
//				localRotation.x += Input.GetAxis ("Mouse X") * mouseSensitivity;
//				localRotation.y -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
//				
//				localRotation.y = Mathf.Clamp (localRotation.y, -90f, 90f);
//			}
//
//			else if(Input.GetMouseButtonUp(0))
//			{
//				down = false;
//			}

			//Rotation of camera based on mouse coordinates
			if(Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0){

				localRotation.x += Input.GetAxis ("Mouse X") * mouseSensitivity;
				localRotation.y -= Input.GetAxis ("Mouse Y") * mouseSensitivity;

				localRotation.y = Mathf.Clamp (localRotation.y, -90f, 90f);

			}
			//Scrolling Input from the mouse scroll wheel
			if(Input.GetAxis ("Mouse ScrollWheel") != 0f){
			//if(Input.GetAxis ("Vertical") != 0f){
				float ScrollAmount = Input.GetAxis ("Mouse ScrollWheel") * scrollSensitivity;
				//float ScrollAmount = Input.GetAxis ("Vertical") * scrollSensitivity;
				ScrollAmount *= (this.cameraDistance * 0.3f);

				this.cameraDistance += ScrollAmount * -1f;
				//Makes sure the camera will go no closer than 1.5 meters and farther than 100 meters
				this.cameraDistance = Mathf.Clamp (this.cameraDistance, 3f, 5f);
			}
		}
			
		//Actual Camera Rig Transformations
		Quaternion QT = Quaternion.Euler (localRotation.y, localRotation.x, 0);
		pivotTransform.rotation = Quaternion.Lerp (this.pivotTransform.rotation, QT, Time.deltaTime * orbitDampening);

		if(cameraTransform.localPosition.z != this.cameraDistance * -1f){

			this.cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp (this.cameraTransform.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollDampening));
		}
	}
}
