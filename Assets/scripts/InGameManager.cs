using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour {

	// Use this for initialization
	public GameObject panelGO,panelWin,textScore,panelCaution,btnPlay,btnPause,btnexitM,panelController,loading;
	DistanceTimer playerIsWin;
	onCollisionPlayerDetection playerhp;

	public Text skorTXT;


	public AudioClip explodeSound;
	public AudioSource sourceExplode;

	public AudioSource sourceAudioIGM;


	void Start () {
		
//		skorTXT.GetComponentInChildren<Text>().enabled=false;
//		skorTXT.enabled = false;
		panelController.gameObject.GetComponent <Image>().enabled=true;
		textScore.SetActive (false);
	
		panelGO.SetActive (false);
		panelWin.SetActive (false);
		playerhp= GameObject.FindGameObjectWithTag ("Player").GetComponent<onCollisionPlayerDetection> ();
		playerIsWin = GameObject.FindGameObjectWithTag ("Player").GetComponent<DistanceTimer> ();
	}

	// Update is called once per frame
	void Update () {
		playerWinOrLose ();

	}

	void playerWinOrLose(){
		if(playerhp.hp==0){
			Time.timeScale = 0;
			panelGO.SetActive (true);
//			skorTXT.enabled = true;
//			skorTXT.GetComponentInChildren<Text>().enabled=true;
			adaptPanel ();
		}

		if(playerIsWin.isWin==true){
			//DO

			Time.timeScale = 0;
			panelWin.SetActive (true);
//			skorTXT.enabled = true;
//			skorTXT.GetComponentInChildren<Text>().enabled=true;
			adaptPanel ();
		}
	}



	public void play(){
		Time.timeScale = 1;
		btnPlay.SetActive (false);
		btnPause.SetActive (true);
		btnexitM.SetActive (false);
	}

	public void pause(){
		Time.timeScale = 0;
		btnPause.SetActive (false);
		btnPlay.SetActive (true);
		btnexitM.SetActive (true);
	}

	void adaptPanel(){
		textScore.SetActive (true);
		skorTXT.text =Player.skor.ToString ();
		panelCaution.SetActive (false);
		panelController.gameObject.GetComponent <Image>().enabled=false;
	}

	public void toMainMenu(){
		StartCoroutine (loadAsync ());
		Player.skor = 0;
	}

	IEnumerator loadAsync(){
		AsyncOperation asyncload = SceneManager.LoadSceneAsync ("MainMenu");
		while (!asyncload.isDone) {
			//Debug.Log (asyncload.progress);
			loading.SetActive (true);
			yield return null;
		
		}
	}

}
