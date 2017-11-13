using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Analysis disable CheckNamespace
public class LoadCountryData : MonoBehaviour {
// Analysis restore CheckNamespace


	public static LoadCountryData ins;
	public List<City> cities;

	public XMLManager xManager;

	public TextAsset cityData;



	// Use this for initialization
	void Awake () {

		cities = new List<City>();
		ins = this;

		cityData = Resources.Load<TextAsset> ("cityData");

		string[] data = cityData.text.Split (new char[] { '\n' });

		for(int i = 1; i < data.Length -1; i++){

			string[] row = data [i].Split (new char[] { ',' });
			City city = new City ();
			city.name = row [0];
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

	public string getCity(UserInput input){

		City userCity = cities.Find (City => City.name == input.userCity);
		string city = userCity.name;

		return city;

	}

	public string getCountry(UserInput input){

		City userCity = cities.Find (City => City.name == input.userCity);
		string country = userCity.country;

		return country;
	}

	public float getLatitude(UserInput input){

		City userCity = cities.Find (City => City.name == input.userCity);
		float latitude = userCity.lat;

		return latitude;
	}

	public float getLongitude(UserInput input){

		City userCity = cities.Find (City => City.name == input.userCity);
		float longitude = userCity.lng;
		return longitude;
	}

	public Color getColor(UserInput input){

		Color markerColor = input.markerColor;
		return markerColor;
	}
}
