using UnityEngine;
using System.Collections;

public class AutoRotation : MonoBehaviour {

	// Use this for initialization

	//this is the rotating speed of the planet in the 3 desired axis
	public Vector3 rotatingSpeed; //rad/s

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.rotation = Quaternion.Euler(rotatingSpeed[0]*Time.fixedTime,rotatingSpeed[1]*Time.fixedTime,rotatingSpeed[2]*Time.fixedTime);
	}
}
