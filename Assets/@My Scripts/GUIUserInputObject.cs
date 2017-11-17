using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Xml.Linq;
public class GUIUserInputObject : MonoBehaviour {

	public Text textInfo;
	public Image imageSprite;
	public UserInput userInput;
	// Use this for initialization
	void Start () {

			
	}

	// Update is called once per frame
	void Update () {

	}

	public void init(UserInput userInput){
		this.userInput = userInput;
		if(textInfo != null){
			textInfo.text = userInput.userName + Environment.NewLine + userInput.userCity;

		}
		//if(sprite != null){
			SetPicture(userInput.userIndex);
			//sprite.sprite = userInput.userIndex;
		//}
	}

	public void SetPicture(int userIndex){

		// Add picture PNG to texture

		byte[] bytes = File.ReadAllBytes (Application.dataPath + "/StreamingAssets/PNG/userPicture" + (PlayerPrefs.GetInt ("User Index") - 1) + ".png");
		Texture2D thisTexture = new Texture2D(900, 900, TextureFormat.RGB24, false);
		thisTexture.filterMode = FilterMode.Trilinear;
		thisTexture.LoadImage (bytes);
		//thisTexture.name = "userPicture";
		Sprite sprite = Sprite.Create (thisTexture, new Rect (0, 0, 900, 900), new Vector2 (0.5f, 9.0f), 1.0f);
		imageSprite.GetComponent<Image> ().sprite = sprite;
		//gameObject.GetComponentInChildren<> ().GetComponentInChildren<Canvas> ().GetComponentInChildren<Image> ().sprite = sprite;
		//gameObject.transform.GetComponentInChildren<Image> ().sprite = sprite;

	}

}
