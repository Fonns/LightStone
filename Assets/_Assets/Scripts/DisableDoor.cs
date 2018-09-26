using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableDoor : MonoBehaviour {

	public List<Pressed> buttons = new List<Pressed>();
	public List<Levered> levers = new List<Levered>();
	public int check;
	public int i;

	Vector3 doormov = new Vector3 (0,10,0);
	Vector3 doorpos = new Vector3(0,0,0);
	public void checkValue(){
		check = 0;
		foreach (var r in buttons){
			if (r.press == false)
				check=0;
			
			if (r.press == true)
				check++;
		}
		foreach (var r in levers){

			if (r.lever == true)
				check++;
		}
		if (check == i) {
			gameObject.transform.position -= doormov;
		} else {
			gameObject.transform.position = doorpos;
		}

	}


	// Use this for initialization
	void Start () {
		doorpos = gameObject.transform.position;
		i = buttons.Count + levers.Count;
		check = 0;
	}
	
	// Update is called once per frame
	void Update () {
		checkValue ();
	}
}
