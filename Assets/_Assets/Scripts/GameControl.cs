using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	
	public int playerhere;
	public int strength;
	float strTimer;
	float strDelay = 30;
	public GameObject aura;

	// Use this for initialization
	void Start () {
		strTimer = strDelay;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.x > -59.5f && gameObject.transform.position.z > -168.1f)
		{
			playerhere = 2;
		} 

		else if (gameObject.transform.position.x > -59.5f && gameObject.transform.position.z < -168.1f)
		{
			playerhere = 3;
		}

		else if (gameObject.transform.position.x < -59.5f)
		{
			playerhere = 1;
		}

		else if (gameObject.transform.position.z > 35f)
		{
			playerhere = 1;
		}
		//Debug.Log (playerhere);

		print (strTimer + strength);

		if (strength == 1) {
			
			aura.SetActive(true);
			strTimer -= Time.deltaTime;

			if (strTimer < 0) {
				strTimer = 0;
			}

			if (strTimer == 0) {
				
				aura.SetActive(false);
				strength = 0;
				strTimer = strDelay;
			}
		}
	}


	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "STR")
			strength = 1;

		if(col.gameObject.tag== "Enemy"){
			strength = 0;
		}
	}
}