using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Mail;

public class PlayerBullet : MonoBehaviour {
	public float speed;
	// Use this for initialization


	void Start () {
		speed = 8f;
	
		//pl=gameObject.GetComponent <Player>();
		}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		transform.position = position;
			
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}

	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "asteroid") {
			Destroy(coll.gameObject);
			Debug.Log ("ketembak");
			Player.skor += 10;
			Player.temp_skor += 10;
		}
		if (coll.gameObject.tag == "comet") {
			Debug.Log ("ketembakKOMETNYA");
			Player.skor += 20;
			Player.temp_skor += 20;
		}

	}



}
