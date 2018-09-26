using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float movSens;
    public Transform mainCamera;
    public float JumpHeight;
    public bool isGrounded;
    bool climbable;
    private CharacterController playerController;
    private Vector3 playerVelocity;

    public AudioClip jog;
    public AudioClip run;

    public Transform tMain;
    public Transform tBlue;
    public Transform tYe;
    public Transform tGreee;
    public Transform tRed;

    private AudioSource audios;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        audios = GetComponent<AudioSource>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audios.enabled = false;
    }

    void Update()
    {
        Vector3 fromCameraToMe = transform.position - mainCamera.transform.position;

        fromCameraToMe.y = 0; 
        fromCameraToMe.Normalize(); 

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

	

        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.position += new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene("main");
        }

        if (Input.GetKey(KeyCode.P))
        {
            GameObject monster = GameObject.Find("monster");
            monster.SetActive(false);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.position = tMain.position;
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            transform.position = tBlue.position;
        }

        if (Input.GetKey(KeyCode.Alpha9))
        {
            transform.position = tYe.position;
        }

        if (Input.GetKey(KeyCode.Alpha8))
        {
            transform.position = tGreee.position;
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            transform.position = tRed.position;
        }

        Vector3 movement = (fromCameraToMe * moveVertical + mainCamera.transform.right * moveHorizontal);

            if (movement != Vector3.zero)
            {
                transform.forward = movement * -1;
            }

        if (climbable == false)
        {
            playerController.Move(movement * Time.deltaTime * movSens);

            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            playerController.Move(playerVelocity * Time.deltaTime);

            if (playerController.isGrounded)
            {
                isGrounded = true;
                playerVelocity.y = 0f;
            }
            /*else
            {
                isGrounded = false;
                //movSens = 2f;
            }*/

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                /*Vector3 bJumpVel = playerVelocity;
                playerVelocity.x = bJumpVel.x;
                playerVelocity.z = bJumpVel.z;*/
                playerVelocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
                isGrounded = false;
                audios.enabled = false;
            }

            if (Input.GetButtonDown("Sprint"))
            {
                audios.clip = run;
                audios.enabled = false;
                
                if (Input.GetButton("Sprint") && isGrounded == true)
                {
                    audios.enabled = true;
                    movSens = 10f;
                    GameObject.FindGameObjectWithTag("Sporty").GetComponent<Actions>().Run();
                }
                
            }
            if (Input.GetButtonUp("Sprint"))
            {
                audios.enabled = false;
            }
            else if (Input.GetButton("Sprint") == false && isGrounded == true)
            {
                movSens = 5f;
                audios.clip = jog;
                audios.enabled = true;
                GameObject.FindGameObjectWithTag("Sporty").GetComponent<Actions>().Walk();

            }
        }
        else if (climbable == true)
        {
			if (moveVertical > 0f && Input.GetButton("Jump") == true)
            {
                playerController.Move(Vector3.up * Time.deltaTime * movSens);
            }
            else if (moveVertical < 0f)
            {
                playerController.Move(Vector3.down * Time.deltaTime * movSens);
            }
        }

		if (Input.anyKey == false) {
			GameObject.FindGameObjectWithTag ("Sporty").GetComponent<Actions> ().Stay ();
            audios.enabled = false;
        }
			
        
    }
		
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            climbable = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            climbable = false;
        }
    }
}