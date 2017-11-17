using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureManager : MonoBehaviour {

	public GameObject retakeMenu; // Assign in inspector
	public GameObject pressSpaceMenu;
	private bool retakeIsShowing = false;
	private bool pressSpaceIsShowing = false;
	public XMLManager xmlManager;


	int cullingMask;
	CameraClearFlags clearFlags;

	void Awake(){

		cullingMask = Camera.main.cullingMask;
		clearFlags = Camera.main.clearFlags;
		}

	void Start(){
		pressSpaceIsShowing = true;

		if (pressSpaceIsShowing) {
			Time.timeScale = 0;
			pressSpaceMenu.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			retakeIsShowing = !retakeIsShowing;

			if (retakeIsShowing) {
				Time.timeScale = 0;
				StartCoroutine (PauseCamera ());
				retakeMenu.SetActive (retakeIsShowing);
			} else{
				Time.timeScale = 1;

				StopCoroutine (PauseCamera ());
				StartCoroutine (ResumeCamera ());
				retakeMenu.SetActive (retakeIsShowing);
			}
			StopCoroutine (ResumeCamera());	

		}
	}

	public void Retake(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OkPressed(){
		Time.timeScale = 1;
		StopCoroutine (PauseCamera ());
		StartCoroutine (ResumeCamera ());
		pressSpaceMenu.SetActive (false);
		StopCoroutine(ResumeCamera ());

	}

	public void Accept(){
		Time.timeScale = 1;
		StopAllCoroutines();
		//Debug.Log ("Before List = " + UserDatabase.inputs.Count); 
		Debug.Log ("Before List = " + XMLManager.ins.userDb.inputs.Count); 
		xmlManager.userDb.inputs = UserListInterface.GetList ();
		xmlManager.SaveUsers ();
		SceneManager.LoadScene ("Localized GPS M1");
	}

	IEnumerator PauseCamera(){

		Debug.Log ("Should Be Paused"); 
		Camera.main.clearFlags = CameraClearFlags.Nothing;
		yield return null;
		Camera.main.cullingMask = 0;
	}

	IEnumerator ResumeCamera(){

		Camera.main.clearFlags = clearFlags;
		yield return null;
		Camera.main.cullingMask = cullingMask;

	}
}
