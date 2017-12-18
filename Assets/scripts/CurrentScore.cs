using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScore : MonoBehaviour {
	int score=0;
	// Use this for initialization

	void Start () {
		
		if (PlayerPrefs.HasKey ("currentSkor")) {
			score = PlayerPrefs.GetInt ("currentSkor");
		} else {
			PlayerPrefs.SetInt ("currentSkor",0);
		}
		Debug.Log ("score jek ntes: "+score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
