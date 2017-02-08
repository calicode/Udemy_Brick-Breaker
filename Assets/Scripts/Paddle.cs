using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	Vector3 mousePosRaw;
	Vector3 mousePosTranslated;
	public bool autoPlay = true;
	private Ball ball;
	private LineRenderer lineRender;
	public float paddleSpeed = 2f;

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
		float hMovement = Input.GetAxis ("Horizontal");
		//float hSpeed = new Vector3(

		//mousePosInBlocks = mousePosRaw.x / Screen.width * 16;
		transform.Translate (hMovement * paddleSpeed, 0f, 0f);
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, 1f, 15f), transform.position.y, 0f);

		DrawMouseAim ();
		//print ("Mouseposraw is" + mousePosRaw + "line is" + lineRender.GetPosition (0) + " And " + lineRender.GetPosition (1)); 

	}

	/// <summary>
	/// Starts autoplay for level testing. Paddle follows ball. 
	/// </summary>
	void DrawMouseAim ()
	{

		mousePosRaw = Input.mousePosition;
		mousePosTranslated = mousePosRaw / Screen.width * 16;
		lineRender.SetPosition (0, this.transform.position);
		lineRender.SetPosition (1, mousePosTranslated);
		// use an arrow sprite here that moves based on mouse. 


	}

	public Vector3 GetMousePositionTranslated ()
	{
		print ("Mouse pos translated is" + mousePosTranslated); 
		return mousePosTranslated - transform.position;
	}

	void AutoPlay ()
	{


		Vector3 paddlePos = new Vector3 (ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	
}
