using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject maincamera;
    public string type;
    private RaycastHit pickobj;
    private float startT;
    private float startD = 30;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Pickable();
            if (type == "strenght")
            {
                pickobj.transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

            }
        }
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
            if (hit.transform.tag == "Button")
            {
                pickobj = hit;
                //hit.transform.position = new Vector3(playerpos.x, playerpos.y + 5, playerpos.z);
            }
        }
    }
}
