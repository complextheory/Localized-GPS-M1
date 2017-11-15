using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class MarkerPositioning : MonoBehaviour {

	public LoadUserData loadCountryData;

	float elapsed;
	// localization variables
	public float lat,lon,R;
	public Color col;
	public Image img;
	public Renderer rend;

	public int userIndex;


	void Start () {
		// setting scale
		transform.localScale=new Vector3(0.00025f,0.00025f,0.00025f);
		//userIndex = loadCountryData.getUserIndex (UserDatabase.inputs);
		SetPicture (userIndex);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		elapsed += Time.fixedDeltaTime;

		if (elapsed > 0.5f) 

			elapsed = 0;

		// re-positionnin sphere coordinates
		float x = Mathf.Cos (lat*Mathf.PI/180) * Mathf.Cos ((lon-90)*Mathf.PI/180) * R;
		float z = Mathf.Cos (lat*Mathf.PI/180) * Mathf.Sin ((lon-90)*Mathf.PI/180) * R;
		float y = Mathf.Sin (lat*Mathf.PI/180) * R;

		// change position
		transform.localPosition = new Vector3 (x, y, z);
		//Debug.Log ("Marker Vector 3 = " + transform.localPosition);
		transform.forward = transform.position;

		// change color and render
		img.color=col;
		rend.material.color = col;
	}	

	public void SetPicture(int userIndex){

		// Add picture PNG to texture

		byte[] bytes = File.ReadAllBytes (Application.dataPath + "/StreamingAssets/PNG/userPicture.png");
		Texture2D thisTexture = new Texture2D(900, 900, TextureFormat.RGB24, false);
		thisTexture.filterMode = FilterMode.Trilinear;
		thisTexture.LoadImage (bytes);
		//thisTexture.name = "userPicture";
		Sprite sprite = Sprite.Create (thisTexture, new Rect (0, 0, 900, 900), new Vector2 (0.5f, 9.0f), 1.0f);
		//gameObject.GetComponentInChildren<> ().GetComponentInChildren<Canvas> ().GetComponentInChildren<Image> ().sprite = sprite;
		gameObject.transform.GetChild (1).GetComponentInChildren<Image> ().sprite = sprite;
	}
}
