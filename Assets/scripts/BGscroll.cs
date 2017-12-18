using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour {
	public float speed=0.5f;
	// Use this for initialization
	Vector3 startpos;
	void Start () {
		startpos = transform.position;
	}

	// Update is called once per frame
	void Update () {
//		Vector2 offset = new Vector2 (Time.time*speed,0);
//		GetComponent<Renderer>().material.mainTextureOffset=offset;
		transform.Translate ((new Vector3(-1,0,0))*speed*Time.deltaTime);

		if (transform.position.x < -18.16)
			transform.position = startpos;
	}
}
