using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Security.Cryptography;

public class GenerateSupply : MonoBehaviour {

	// Use this for initialization
	public GameObject supplyammo;
	public GameObject supplyhp;
	//public bool ActivateS,ActivateHP;
	public float ratioM1, ratioM2, ratioH1, ratioH2;
	void Start () {
	//	ActivateS = true;
	//	ActivateHP = true;
		InvokeRepeating ("CreateSupplyAmmo", ratioM1, ratioM2);
		InvokeRepeating ("CreateSupplyHP",ratioH1,ratioH2);
	}

	void Update(){
//		if (ActivateS) {
//			
//		}
//		if(ActivateHP){
//			
//		}
	}
	
	// Update is called once per frame
	void CreateSupplyAmmo(){
		Instantiate (supplyammo);
	}

	void CreateSupplyHP(){
		Instantiate (supplyhp);
	}


}
