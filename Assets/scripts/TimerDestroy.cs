using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour {
	public float timedestroy=2f;
	// Use this for initialization
	void Start () {
		StartCoroutine (Destroy ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (timedestroy);
		Destroy (gameObject);
	}
}
