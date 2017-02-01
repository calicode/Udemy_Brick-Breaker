using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	float mousePosInBlocks = 0;
	public bool autoPlay = true;
	private Ball ball;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	// Update is called once per frame
	void Update ()
	{ 
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}


	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Paddle Collider is" + collision.gameObject);
		float frictionTweak = this.transform.position.x / 5;
		collision.rigidbody.velocity = new Vector3 ((collision.rigidbody.velocity.x + frictionTweak), collision.rigidbody.velocity.y, 0f);

	}

	/// <summary>
	/// Moves the with mouse.
	/// </summary>
	void MoveWithMouse ()
	{


		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePos;

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
