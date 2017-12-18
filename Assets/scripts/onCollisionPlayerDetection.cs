using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using Random=UnityEngine.Random;

public class onCollisionPlayerDetection : MonoBehaviour {
	public int hp=100;

	public SpriteRenderer hp1,hp2,hp3,hp4,hp5;
	public GameObject Explosion;
	InGameManager soundExplode;

	// Use this for initialization
	void Start () {
		soundExplode = GameObject.FindGameObjectWithTag ("igm").GetComponent<InGameManager> ();
		EnablerHP ();
	}
	
	// Update is called once per frame
	void Update () {
		EnablerHP ();

	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag=="asteroid"){
			soundExplode.sourceExplode.PlayOneShot (soundExplode.explodeSound,Random.Range (1f, 5f));
		
			Instantiate (Explosion,transform.position,transform.rotation);
			Destroy (coll.gameObject);
			hp = hp - 20;
			EnablerHP ();
			highscoring ();
		}
		else if(coll.gameObject.tag=="comet"){
			//soundExplode.sourceExplode.Play ();
			soundExplode.sourceExplode.PlayOneShot (soundExplode.explodeSound,Random.Range (1f, 5f));
			Destroy (coll.gameObject);
			hp = hp - 20;
			EnablerHP ();
			highscoring ();
		}
	}


	void highscoring(){
		if(hp<=0){
			//int currentscore=0;
//			DistanceTimer.CurrentScore+=skorMain.skor;

			int higScoreSkg = 0;
			higScoreSkg = PlayerPrefs.GetInt ("Skor");
		
			//currentscore = skorMain.skor;
			//currentscore = PlayerPrefs.GetInt ("currentSkor");
			//PlayerPrefs.SetInt ("currentSkor", currentscore);
//			if(DistanceTimer.CurrentScore>=skorMain.skor){
//				skorMain.skor = DistanceTimer.CurrentScore;
//			}

			if (Player.skor > higScoreSkg) {
				PlayerPrefs.SetInt ("Skor", Player.skor);
			} else {
				PlayerPrefs.SetInt ("Skor", higScoreSkg);
			}
		
		//	SceneManager.LoadScene ("gameOver");

		}
	}



	void EnablerHP(){
		if(hp==100){
			hp1.enabled = true;
			hp2.enabled = true;
			hp3.enabled = true;
			hp4.enabled = true;
			hp5.enabled = true;
		}
		else if(hp==80){
			hp1.enabled = true;
			hp2.enabled = true;
			hp3.enabled = true;
			hp4.enabled = true;
			hp5.enabled = false;
		}
		else if(hp==60){
			hp1.enabled = true;
			hp2.enabled = true;
			hp3.enabled = true;
			hp4.enabled = false;
			hp5.enabled = false;
		}
		else if(hp==40){
			hp1.enabled = true;
			hp2.enabled = true;
			hp3.enabled = false;
			hp4.enabled = false;
			hp5.enabled = false;
		}
		else if(hp==20){
			hp1.enabled = true;
			hp2.enabled = false;
			hp3.enabled = false;
			hp4.enabled = false;
			hp5.enabled = false;
		}
		else if(hp==0){
			hp1.enabled = false;
			hp2.enabled = false;
			hp3.enabled = false;
			hp4.enabled = false;
			hp5.enabled = false;
		}

	}
}
