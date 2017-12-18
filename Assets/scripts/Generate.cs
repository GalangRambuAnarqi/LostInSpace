using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	// Use this for initialization
	public GameObject rocks;
	public float ratio1,ratio2;
//	int score=0;
	public bool activate;
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

//	void OnGUI(){
//		GUI.color = Color.black;
//		GUILayout.Label ("Score: "+score.ToString());
//	}
	// Update is called once per frame

	void CreateObstacle(){
		Instantiate (rocks);
//		score++;
	}


}
