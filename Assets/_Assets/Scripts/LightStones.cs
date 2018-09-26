using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStones : MonoBehaviour {


	public GameObject brick;
	public GameObject gate;

    public AudioSource MontersRoar;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up * Time.deltaTime * 200);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MontersRoar.Play();
            Destroy(gameObject);
			brick.SetActive(true);
			gate.SetActive (false);
        }
    }
}
