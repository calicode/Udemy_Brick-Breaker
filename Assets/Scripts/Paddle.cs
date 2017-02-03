using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	float mousePosInBlocks = 0;
	Vector3 mousePosRaw;
	public bool autoPlay = true;
	private Ball ball;
	private LineRenderer lineRender;
	private int paddleSpeed = 10;

	// Use this for initialization
	void Start ()
	{
		lineRender = GetComponent <LineRenderer> ();
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	// Update is called once per frame
	void Update ()
	{ 
		if (!autoPlay) {
			PlayerControlledMovement ();
		} else {
			AutoPlay ();
		}


	}



	/// <summary>
	/// Players the controlled movement.
	/// </summary>
	void PlayerControlledMovement ()
	{
		float hMovement = Input.GetAxisRaw ("Horizontal");
		float hSpeed = Mathf.Clamp (hMovement, 1f, 15f);

		mousePosRaw = Input.mousePosition;
		//mousePosInBlocks = mousePosRaw.x / Screen.width * 16;
		print ("hSpeed is" + hSpeed); 
		transform.position = new Vector3 (hSpeed, 0f, 0f);	
		lineRender.SetPosition (0, this.transform.position);
		lineRender.SetPosition (1, mousePosRaw / Screen.width * 16);


		//print ("Mouseposraw is" + mousePosRaw + "line is" + lineRender.GetPosition (0) + " And " + lineRender.GetPosition (1)); 

	}

	/// <summary>
	/// Starts autoplay for level testing. Paddle follows ball. 
	/// </summary>
	void AutoPlay ()
	{


		Vector3 paddlePos = new Vector3 (ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	
}
