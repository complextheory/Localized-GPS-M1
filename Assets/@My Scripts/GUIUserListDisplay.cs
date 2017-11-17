using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Internal.Filters;

public class GUIUserListDisplay: MonoBehaviour {

	public List<UserInput> selectedUserList; 
	public Transform targetTransform;
	public 

	// Use this for initialization
	void Start () {
		selectedUserList = new List<UserInput>();

		bool TESTING = true;
		if(TESTING){
			selectedUserList = UserListInterface.GetList();
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
