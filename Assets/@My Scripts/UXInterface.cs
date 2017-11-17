using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UXInterface  {


	public static List<UserInput> tempList;

	void Start (){

		tempList = UserListInterface.GetList ();
	}
//	void Switch(){
//
//		int tempSelect = 1;
//
//		switch (tempSelect){
//
//			case 1:
//			UserListInterface.RemoveUser ()
//				ShowCurrentList ();
//				break;
//			
//			case 2:
//				realDataList.remove (SelectedUser);
//				break;
//
//			case 3:
//				SceneManager.LoadScene ("Main Menu");
//				break;
//
//			case 4:
//				
//		}
	//}

//	public static void SetList(){
//
//		tempList = UserListInterface.GetList ();
//	}

	public static void AddUser(UserInput user){

		tempList.Add (user);
		ShowCurrentList ();

	}

	public static void RemoveUser(UserInput user){
		tempList.Remove (user);
		ShowCurrentList ();
	}

	public static void ShowCurrentList(){
			
		Debug.Log ("TempList = " + tempList.Count);
		Debug.Log ("RealList = " + UserListInterface.GetList ().Count);

	}
	 
	public static void ChangeScene(){

		SceneManager.LoadScene ("Main Menu");
	}

}
