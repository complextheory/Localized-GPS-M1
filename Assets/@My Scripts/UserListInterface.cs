using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserListInterface {

	//public UserListManager ins;

	static List <UserInput>list;

//	void Awake (){
//		InitializeList ();
//	}

	void Start (){
		//XMLManager.LoadUsers ();
		//list = UserDatabase.inputs;
	}
	public static void InitializeList ()
	{
		
		Debug.Log ("Initializing List");

		//XMLManager.LoadUsers ();
		//list = UserDatabase.inputs;
		if(XMLManager.ins.userDb.inputs.Count == 0 || XMLManager.ins.userDb.inputs == null){
			list = new List<UserInput> ();	
		}else
		list = XMLManager.ins.userDb.inputs;

//		if (true) {
//
//			List<string> names = new List<string> {"Thomas", "Edward", "Henry", "Jason", "Penelope", 
//				"Kirt"
//			};
//			List<string> testCities = new List<string> {"Mobaye", "New York", "Dhaka", "Ravensthorpe",
//				"Yerevan", "Eisenstadt"
//			};
//			List<Color> colors = new List <Color> {Color.blue, Color.gray, Color.yellow, Color.blue,
//				Color.cyan, Color.red
//			};
//			//list = new List<UserInput> ();
//
//			for (int i = 0; i < testCities.Count; i++) {
//				UserInput tempUser = new UserInput ();
//				tempUser.userName = names[i];
//				tempUser.userCity = testCities[i];
//				tempUser.pictureName = "userPicture";
//				Debug.Log ("User Picture = " + tempUser.pictureName); 
//				tempUser.markerColor = colors[i];
//				list.Add (tempUser);
//			}
//			Debug.Log ("List = " + list.Count);
//		}else 
//			list = new List<UserInput>();
	}
			

	public static void SetList(List<UserInput> loadedList){

		list = loadedList;
	}

	public static void AddUser(UserInput user){

		list.Add (user);
	}

	public static void RemoveUser(UserInput user){
		list.Remove (user);
	}

	public static List<UserInput> GetList(){
		return list;
	}

	public static int GetTotalUsers(){
		return list.Count;
	}


	//Category 1 == Name 2 == Country. Reverse is whether to sort reverse or not
	public static void SortList(int categoryNumber,bool reverse){

		//sort by name alphabetecal order
		if(categoryNumber == 1 && reverse == false){
			
			list.Sort((user1, user2) => user1.userName.CompareTo(user2.userName));
		}

		if(categoryNumber == 1 && reverse == true){
			
			list.Sort((user1, user2) => user2.userName.CompareTo(user1.userName));
		}

		if(categoryNumber == 2 && reverse == false){

			list.Sort ((user1, user2) => user1.userCity.CompareTo (user2.userCity));
		}

		if(categoryNumber == 2 && reverse == true){

			list.Sort ((user1, user2) => user2.userCity.CompareTo (user1.userCity));
		}


	}
}
