using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour {

	public Slider cSlider;
	//Color32[] colors;
	Color[] colors;
	float ColSlidervalue = 3f;

	public Animator anim;
	//public Animation anim;

	void Awake()
	{
//		colors = new Color32[4] { new Color32(0, 0, 255, 255),
//			new Color32(0, 255, 0, 255),
//			new Color32(255, 0, 0, 255),
//			new Color32(0, 0, 0, 255) };

		colors = new Color[6] {
			Color.white,
			Color.black,
			Color.blue,
			Color.green,
			Color.cyan,
			Color.gray
		};

		/*use this and change the name in the quotes to whatever the slider's
        name is in the scene hierarchy if you decide not to assign the slider
        in the inspector*/
		//cSlider = GameObject.Find("HierarchyNameOfSlider").GetComponent<Slider>();
		cSlider.value = ColSlidervalue;
	}

	public void ChangeColour(float value)
	{
		Debug.Log ("ChangeColor Called Value = " + value);
//		if (value == 0f)
//		{
////			gameObject.GetComponent<Renderer>().material.color = Colors[0];
//			gameObject.GetComponent<Image>().color = colors[0];
//		}
//		if (value == 1f)
//		{
////			gameObject.GetComponent<Renderer>().material.color = Colors[1];
//			gameObject.GetComponent<Image>().color = colors[1];
//		}
//		if (value == 2f)
//		{
////			gameObject.GetComponent<Renderer>().material.color = Colors[2];
//			gameObject.GetComponent<Image>().color = colors[2];
//		}
//		if (value == 3f)
//		{
////			gameObject.GetComponent<Renderer>().material.color = Colors[3];
//			gameObject.GetComponent<Image>().color = colors[3];
//		}

		for(int i = 0; i < colors.Length; i++){

			if(value == i)
				gameObject.GetComponent<Image>().color = colors[i];

			if (colors [i] == Color.green || colors [i] == Color.cyan || colors [i] == Color.white) {
				gameObject.GetComponentInParent<Button> ().GetComponentInChildren<Text> ().color = colors [1];
				//anim.Stop ();
				//anim.StopPlayback ();
			}
		}
	}
}
