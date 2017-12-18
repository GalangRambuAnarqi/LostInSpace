using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	public Vector2 velocity=new Vector2(-4,0);
	public float range;
	public GameObject Explosion;
	InGameManager soundExplode;

	// Update is called once per frame
	void Start () {
		soundExplode = GameObject.FindGameObjectWithTag ("igm").GetComponent<InGameManager> ();
		GetComponent<Rigidbody2D> ().velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - range * Random.value, transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "bullet") {
			Destroy(coll.gameObject);
			Instantiate (Explosion,transform.position,transform.rotation);
			soundExplode.sourceExplode.PlayOneShot (soundExplode.explodeSound,Random.Range (1f, 5f));
		}

	}


}
