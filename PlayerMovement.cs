
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public MovementTwo controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool inPause;

	Transform t;
	
	void Start (){
		t = transform;
	}
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetKey(KeyCode.W))
		{
			jump = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find ("UI").GetComponent<UI> ().PauseGame();
		}

	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	
	public void MoveTo(Transform newPosition){
		t.position = newPosition.position;
	}
}