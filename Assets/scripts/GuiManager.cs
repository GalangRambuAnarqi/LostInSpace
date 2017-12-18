using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class GuiManager : MonoBehaviour {


	public Text HighScore,currentskor;
	int score=0,tempskor=0;

	public int idxScene;

	// Use this for initialization
	public GameObject panelCredit,panelHelp,panelSetting;
	public GameObject icon;

	public AudioClip soundBTN;
	public AudioSource btnSource;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

//		PlayerPrefs.SetInt ("Skor",0);
		panelCredit.SetActive (false);
		panelHelp.SetActive (false);

		//tempskor = PlayerPrefs.GetInt ("currentSkor");
		//currentskor.text = tempskor.ToString ();

		if (PlayerPrefs.HasKey ("Skor")) {
			score = PlayerPrefs.GetInt ("Skor");
		} else {
			PlayerPrefs.SetInt ("Skor",0);
		}
		if(HighScore)
			HighScore.text =score.ToString ();

		settingSound ();
	}
	
	// Update is called once per framea
	void Update () {
		Debug.Log (PlayerPrefs.GetInt ("Muted"));
	}

	void settingSound(){
		if (PlayerPrefs.GetInt ("Muted") == 0) {
			soundOff ();
		} else if(PlayerPrefs.GetInt ("Muted") == 1){
			soundOn ();
		}
	}


	public void loadScene(int idx){
		SceneManager.LoadScene (idx);
	}


	public void retry(int idx){
		SceneManager.LoadScene (idx);
		Player.skor = Player.skor - Player.temp_skor;
	
	}

	public void onPlay(){
		SceneManager.LoadScene ("scene1");
		btnSource.Play ();	
	}

	public void onCredit(){
		panelCredit.SetActive (true);
		icon.SetActive (false);

		}

	public void onHelp(){
		panelHelp.SetActive (true);
		icon.SetActive (false);
	
	}

	public void exitCredit(){
		panelCredit.SetActive (false);
		icon.SetActive (true);

			}
	public void exitHelp(){
		panelHelp.SetActive(false);
		icon.SetActive (true);
	}

	public void onSetting(){
		panelSetting.SetActive (true);
		icon.SetActive (false);
	}

	public void exitSetting(){
		panelSetting.SetActive (false);
		icon.SetActive (true);
	}

	public void ToggleSound()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) 
		{
			PlayerPrefs.SetInt ("Muted", 1);
			soundOn ();
		} else 
		{
			PlayerPrefs.SetInt ("Muted", 0);
			soundOff ();
		}
	}

	void soundOn(){
		AudioListener.volume = 1;
	}
	void soundOff(){
		AudioListener.volume = 0;
	}


	public void help(){
		SceneManager.LoadScene ("help");
	
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
		Player.skor = 0;
	
	}


	public void onExit(){
		Application.Quit ();
	
	}


		




}
