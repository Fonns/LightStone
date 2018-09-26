using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {


	Rigidbody climb;

	// Use this for initialization
	void Start(){
		climb = GetComponent<Rigidbody> ();
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "Player")
			climb.constraints = RigidbodyConstraints.FreezeAll; 
		
		}

	void OnCollisionExit(Collision col){
		climb.constraints = ~RigidbodyConstraints.FreezePositionY;


	}
}
