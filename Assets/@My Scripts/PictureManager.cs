using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureManager : MonoBehaviour {

	public GameObject menu; // Assign in inspector
	private bool isShowing = false;

	int cullingMask;
	CameraClearFlags clearFlags;

	void Awake(){

		cullingMask = Camera.main.cullingMask;
		clearFlags = Camera.main.clearFlags;
		Debug.Log("LIST IS NOW: " +UserListInterface.GetList().Count);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			isShowing = !isShowing;

			if (isShowing) {
				Time.timeScale = 0;
				StartCoroutine (PauseCamera ());
				//PauseCamera ();
				menu.SetActive (isShowing);
			} else{
				Time.timeScale = 1;
				//ResumeCamera ();
				StopCoroutine (PauseCamera ());
				StartCoroutine (ResumeCamera ());
				menu.SetActive (isShowing);
			}
			StopCoroutine (ResumeCamera());	

		}
	}

	public void Retake(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Accept(){
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
