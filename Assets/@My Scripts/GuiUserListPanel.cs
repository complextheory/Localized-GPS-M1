using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiUserListPanel : MonoBehaviour {

	public GUIUserInputObject userInputObjectPrefab;
	public List<UserInput> selectedUsersList;
	public Transform parentObject;


	// Use this for initialization

	void Start () {

		selectedUsersList = UserListInterface.GetList ();


		init(selectedUsersList);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init(List<UserInput> userInputs){


		foreach(UserInput user in userInputs){
			GUIUserInputObject displayItem = (GUIUserInputObject)Instantiate(userInputObjectPrefab);
			displayItem.transform.SetParent(parentObject, false);
			Debug.Log(user.userName);
			displayItem.init(user);
		}
	}
}
