using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour {

    public GameObject maincamera;
    private Vector3 playerpos;
    private RaycastHit pickobj;
    private bool pickkk;
    public Transform playerFront;
	public bool heavy;
	public GameObject climby;
	float width;


	// Use this for initialization
	void Start () {

		width = GetComponent<Renderer>().bounds.size.z;

        pickkk = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (heavy == true) {

			if (pickkk == true) {
				climby.GetComponent<Collider> ().isTrigger = false;
			} else if (pickkk == false) {
				climby.GetComponent<Collider> ().isTrigger = true;

			}
		}

        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (pickkk)
        {
			pickobj.transform.position = playerFront.transform.position + new Vector3(0, 1, 0);

			pickobj.transform.forward = playerFront.transform.forward;
            pickobj.rigidbody.isKinematic = true;

            if (Input.GetButtonDown("Use"))
            {
                pickobj.rigidbody.isKinematic = false;
                pickobj = new RaycastHit();
                pickkk = false;
            }
        }

        if (Input.GetButtonDown("Use") && pickkk == false)
        {
            Pickable();
        }

        /*if (pickobj.transform.gameObject.GetComponent<PickupObj>().heavy == true)
        {

            if (Input.GetButton("Use"))
            {
                pickobj.rigidbody.isKinematic = true;
                pickobj.transform.position = new Vector3(playerpos.x, pickobj.transform.position.y, playerpos.z - 2);
            }

            if (Input.GetButtonUp("Use"))
            {
                pickobj.rigidbody.isKinematic = false;
                pickobj = new RaycastHit();
            }
        }
        else
        {

            if (Input.GetButton("Use"))
            {
                pickobj.rigidbody.isKinematic = true;
                pickobj.transform.position = new Vector3(playerpos.x, playerpos.y + 3, playerpos.z);
            }

            if (Input.GetButtonUp("Use"))
            {
                pickobj.rigidbody.isKinematic = false;
                pickobj = new RaycastHit();
            }
        }*/
    }

    void Pickable()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        //Debug.Log("ola");

        Ray ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("ola");
            if (hit.transform.tag == "PickupYes")
            {
                pickobj = hit;
                Debug.Log(hit.transform.name);
                pickkk = true;
                //hit.transform.position = new Vector3(playerpos.x, playerpos.y + 5, playerpos.z);
            }

			if (hit.transform.tag == "PickupHeavy" && GameObject.FindGameObjectWithTag ("Player").GetComponent<GameControl> ().strength == 1)
			{
				pickobj = hit;
				Debug.Log(hit.transform.name);
				pickkk = true;
				//hit.transform.position = new Vector3(playerpos.x, playerpos.y + 5, playerpos.z);
			}
        }
    }
}
