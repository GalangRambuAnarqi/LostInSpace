using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class Player : MonoBehaviour {
	public GameObject playerBullet;
	public GameObject BulletPosition;
	float H,V;
	public Text teksbullet;
	public int bullet_num=3;
	public GameObject panelCaution;
	public float speed=3.0f;
	// Use this for initialization
	public Vector2 jumpforce=new Vector2(0,10000);
	public Text TXTScore; 
	public static int skor=0;
	public static int temp_skor=0;
 	int highscore=0;

	float timeKillSelf=0;

	bool L=false,R=false;

	public AudioClip shootSound;
	private float throwSpeed = 2000f;
	public AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	public AudioClip itemColSound;
	public AudioSource soundItem;

//	public AudioClip alertSound;
//	public AudioSource soundAlert;




	onCollisionPlayerDetection playerhp;

	void Start(){
//		AudioSource shoot = GetComponent<AudioSource> ();
		panelCaution.SetActive (false);
		playerhp = GameObject.FindGameObjectWithTag ("Player").GetComponent<onCollisionPlayerDetection> ();
		temp_skor = 0;
	}

	// Update is called once per frame
	void Update () {
//		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
////		if(screenPosition.y>Screen.height||screenPosition.y<0){
//			//Die ();
//		}
		//Shoot ();
		Move ();
		Scoring ();	
		if (L) {
			transform.Rotate (Vector3.forward, 90 * Time.deltaTime, Space.World);
		}
		if (R) {
			transform.Rotate (Vector3.back, 90 * Time.deltaTime, Space.World);
		}
//		currentskor += skor;
//		Debug.Log ("skor saat ini : "+currentskor);
			
	}

	public void Scoring(){
		teksbullet.text = bullet_num.ToString ();
		TXTScore.text = "Score : "+temp_skor.ToString ();
	
		//skor++;
	}	


	public void Shoot(){
//		if (Input.GetKeyDown ("space")) {
//			if (bullet_num > 0) { 
//				GameObject bullet = (GameObject)Instantiate (playerBullet);
//				bullet.transform.position = BulletPosition.transform.position;
//				bullet_num = bullet_num - 1;
//			}
//		}
		if (bullet_num > 0) { 
			GameObject bullet = (GameObject)Instantiate (playerBullet);
			bullet.transform.position = BulletPosition.transform.position;
			bullet_num = bullet_num - 1;
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(shootSound,vol);
		}
	} 


	

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "supplyammo") {
			bullet_num += 3;
			Destroy (coll.gameObject);
			soundItem.Play ();
		}
		if (coll.gameObject.tag == "supplyhp") {
			playerhp.hp+=20;
			if (playerhp.hp > 100){playerhp.hp = 100;}
			Destroy (coll.gameObject);
			soundItem.Play ();
		}


	}

	void OnTriggerStay2D(Collider2D coll){
		
		if (coll.gameObject.tag == "colliderscreen") {

			panelCaution.SetActive (true);
			//soundAlert.Play ();
			if (timeKillSelf >= 4f) {
				playerhp.hp -= 20;
				timeKillSelf=0;
			}
			timeKillSelf = timeKillSelf+1*Time.deltaTime;
		
		}
	}
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "colliderscreen") {
			Debug.Log ("Di dalam kolider");
			panelCaution.SetActive (false);
		}
	}



	public void Move(){
		H=CrossPlatformInputManager.GetAxis("Horizontal");
		V=CrossPlatformInputManager.GetAxis("Vertical");
		transform.position = transform.position + new Vector3 (H, V,0f)*speed*Time.deltaTime;
//
//		if (Input.GetKey (KeyCode.D)) {
//			transform.Rotate (Vector3.back, 90 * Time.deltaTime, Space.World);
//		
//		}
//		if (Input.GetKey (KeyCode.A)) {
//			transform.Rotate (Vector3.forward,90*Time.deltaTime,Space.World);
//		}
//		//GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//	GetComponent<Rigidbody2D>().AddForce (jumpforce);
	}
		

	public void pressedL(){
		L = true;
	}

	public void releaseL(){
		L = false;
	}

	public void pressedR(){
		R = true;
	}

	public void releaseR(){
		R = false;
	}



	/*
	void OnCollisionEnter2D(Collision2D other){
		Die();
	}
	void Die(){
		SceneManager.LoadScene ("scene1");
	}*/
}
