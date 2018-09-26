using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levered : MonoBehaviour {
	public bool lever = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "Player")
			lever = true;
	}

}
