using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatemeteor : MonoBehaviour {

	// Use this for initialization
	public GameObject meteor;
	public bool activate;
	public float ratio1,ratio2;
	void Start () {
		activate = true;
		if(activate)
			InvokeRepeating ("CreateObstacle",ratio1,ratio2);
	}
	void Update(){
		if (activate==false) {
			CancelInvoke ("CreateObstacle");
		}
	}

	void CreateObstacle(){
		Instantiate (meteor);
	}
}
