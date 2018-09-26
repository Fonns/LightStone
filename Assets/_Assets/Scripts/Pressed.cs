using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour {
	public bool press = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "PickupYes" || col.gameObject.tag == "PickupHeavy")
			press = true;
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "PickupYes" || col.gameObject.tag == "PickupHeavy")
			press = false;
	}


}
