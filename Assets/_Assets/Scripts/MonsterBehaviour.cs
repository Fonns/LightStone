using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class MonsterBehaviour : MonoBehaviour {

    public Transform player;
	public List<Transform> temple = new List<Transform>();
	public List<Transform> market = new List<Transform>();
	public List<Transform> forest = new List<Transform>();
	public Transform last_pos;
	public float dist;
	public float follow;
    public AudioSource roar;
    private bool seen;


	// Use this for initialization

	void patrolTemple (){
		last_pos = temple [Random.Range (0, temple.Count)];
		transform.GetComponent<NavMeshAgent>().destination = last_pos.position;

	}

	void patrolMarket (){
		last_pos = market [Random.Range (0, market.Count)];
		transform.GetComponent<NavMeshAgent>().destination = last_pos.position;

	}

	void patrolForest (){
		last_pos = forest [Random.Range (0, forest.Count)];
		transform.GetComponent<NavMeshAgent>().destination = last_pos.position;

	}

	void Start () {
		patrolTemple ();
        seen = false;
	}
	
	// Update is called once per frame
	void Update () {

		//transform.GetComponent<NavMeshAgent>().destination = player.position;
		if (Vector3.Distance (gameObject.transform.position, last_pos.position) < dist && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 1)
			patrolTemple ();

		if (Vector3.Distance (gameObject.transform.position, last_pos.position) < dist && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 2)
			patrolMarket ();

		if (Vector3.Distance (gameObject.transform.position, last_pos.position) < dist && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 3)
			patrolForest ();
	

		if (Vector3.Distance (gameObject.transform.position, player.position) < follow) {
            if (seen == false) { roar.Play(); seen = true; }
            transform.GetComponent<NavMeshAgent> ().destination = player.position;
			gameObject.GetComponent<NavMeshAgent> ().speed = 7.5f;
		}
		else
		{
			transform.GetComponent<NavMeshAgent> ().destination = last_pos.position;
			gameObject.GetComponent<NavMeshAgent> ().speed = 5;
            seen = false;
		}

	}

		
	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "door" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 1)
			patrolTemple();

		else if(col.gameObject.tag == "door" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 2)
			patrolMarket();

		else if(col.gameObject.tag == "door" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().playerhere == 3)
			patrolForest();

		if (col.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().strength == 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		
		if (col.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().strength == 1)
			GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().strength = 0;
	}
}