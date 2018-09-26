using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NextScene : MonoBehaviour {


	public GameObject texty;
    public float time;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitSeconds(time, DeleteText));
    }
	
	// Update is called once per frame
	void Update () {
        
    }



    private IEnumerator WaitSeconds(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }


    private void DeleteText()
    {
		texty.SetActive (false);
    }

}
