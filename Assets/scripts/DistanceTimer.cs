using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SocialPlatforms.GameCenter;

public class DistanceTimer : MonoBehaviour {

	float endTime;
	public Text textMesh;
	//public GameObject textWin;
	public static int CurrentScore=0;
	public int distance;
	public Generate gnMeteor;
	public Generatemeteor gnMeteor2;
	//public GameObject gnSupply;
	public bool isWin=false;
	int inc = 5;
	// Use this for initialization
	void Start () {
		endTime = Time.time + distance;
		InvokeRepeating ("autoscore",2.0f,2.0f);
		gnMeteor= GameObject.FindGameObjectWithTag ("meteor").GetComponent<Generate> ();
		gnMeteor2= GameObject.FindGameObjectWithTag ("comet").GetComponent<Generatemeteor> ();
	//	gnSupply = GameObject.FindGameObjectWithTag ("supplyammo").GetComponent <GenerateSupply>();
	
	}
	
	// Update is called once per frame
	void Update () {
		distanceLeft ();
	
	}

	void distanceLeft(){
		float timeLeft = (float)endTime - Time.time;
		if (timeLeft < 0)
		timeLeft = 0;
		timeLeft = (float)System.Math.Round (timeLeft, 2);
		textMesh.text = "Distance Left : " + timeLeft.ToString ();
		if(timeLeft==0){
		endthegame();
		
		}
	}

	void endthegame(){
		if (gnMeteor.activate) {
			CancelInvoke ("autoscore");
		}
		gnMeteor.activate = false;
		gnMeteor2.activate = false;
	//	gnSupply.ActivateHP = false;
	//	gnSupply.ActivateS = false;
		StartCoroutine (Ending ());
		//
	}

	IEnumerator Ending(){
		//Instantiate (textWin);
		highscoring ();
		yield return new WaitForSeconds (12f);
	
		isWin = true;

	}

	void autoscore(){
		Player.skor += inc;
		Player.temp_skor += inc;
	}

	void highscoring(){

			//int currentscore=0;

			int higScoreSkg = 0;
			higScoreSkg = PlayerPrefs.GetInt ("Skor");

			//currentscore = skorMain.skor;
			//currentscore = PlayerPrefs.GetInt ("currentSkor");
			//PlayerPrefs.SetInt ("currentSkor", currentscore);

		if (Player.skor > higScoreSkg) {
			PlayerPrefs.SetInt ("Skor", Player.skor);
			} else {
				PlayerPrefs.SetInt ("Skor", higScoreSkg);
			}
			//	SceneManager.LoadScene ("gameOver");
	}

}
