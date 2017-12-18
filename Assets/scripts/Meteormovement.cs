using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteormovement : MonoBehaviour {

	// Use this for initialization
	public Vector2 velocity=new Vector2(-4,0);
	public float range = 4;
	public GameObject Explosion;
	InGameManager soundExplode;
	// Update is called once per frame
	void Start () {
		soundExplode = GameObject.FindGameObjectWithTag ("igm").GetComponent<InGameManager> ();
		GetComponent<Rigidbody2D> ().velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - range * Random.value, transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D other){
			//gameObject.GetComponent<Renderer>().enabled=false;
		Instantiate (Explosion,transform.position,transform.rotation);
		Destroy(gameObject);

		if (other.gameObject.tag == "bullet") {
			Destroy (other.gameObject);
		}
		soundExplode.sourceExplode.PlayOneShot (soundExplode.explodeSound,Random.Range (1f, 5f));
	}
}
