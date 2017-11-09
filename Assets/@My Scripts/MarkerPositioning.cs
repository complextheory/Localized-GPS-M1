using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarkerPositioning : MonoBehaviour {

	// Use this for initialization
	float elapsed;
	// localization variables
	public float lat,lon,R;
	public Color col;
	public Image img;
	public Renderer rend;

	void Start () {
		// setting scale
		transform.localScale=new Vector3(0.0003f,0.0003f,0.0003f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		elapsed += Time.fixedDeltaTime;

		if (elapsed > 0.5f) 
		{
			elapsed = 0;

			// re-positionnin sphere coordinates
			float x = Mathf.Cos (lat*Mathf.PI/180) * Mathf.Cos ((lon-90)*Mathf.PI/180) * R;
			float z = Mathf.Cos (lat*Mathf.PI/180) * Mathf.Sin ((lon-90)*Mathf.PI/180) * R;
			float y = Mathf.Sin (lat*Mathf.PI/180) * R;

			// change position
			transform.localPosition = new Vector3 (x, y, z);
			transform.forward = transform.position;

			// change color and render
			img.color=col;
			rend.material.color = col;
		}
		
	}
}
