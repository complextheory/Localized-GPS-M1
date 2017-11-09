using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCountryData : MonoBehaviour {

	List<City> cities = new List<City>();

	// Use this for initialization
	void Start () {
		TextAsset cityData = Resources.Load<TextAsset> ("cityData");

		string[] data = cityData.text.Split (new char[] { '\n' });

		for(int i = 1; i < data.Length -1; i++){

			string[] row = data [i].Split (new char[] { ',' });
			City city = new City ();
			city.city = row [0];
			city.city_ascii = row [1];
			float.TryParse (row [2], out city.lat);
			float.TryParse (row [3], out city.lng);
			int.TryParse (row [4], out city.pop);
			city.country = row [5];
			city.iso2 = row [6];
			city.iso3 = row [7];
			city.province = row [8];

			cities.Add (city);
		}
			
	}

	// Update is called once per frame
	void Update () {
		
	}
}
