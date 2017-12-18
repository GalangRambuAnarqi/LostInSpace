using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyMovement : MonoBehaviour {

	// Use this for initialization
	public Vector2 velocity=new Vector2(-4,0);
	public float range = 4;
	// Update is called once per frame
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - range * Random.value, transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D other){
		//gameObject.GetComponent<Renderer>().enabled=false;
		Destroy(gameObject);

	}
}