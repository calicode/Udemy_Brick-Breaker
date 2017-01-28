using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Vector3 paddleToBallVector;
	private Paddle paddle;
	public Rigidbody2D rb;
	private bool hasStarted = false;
	AudioSource audioClip;

	// Use this for initialization
	void Start ()
	{
		audioClip = GetComponent <AudioSource> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//this.transform.position = new Vector3 (paddle.transform.position.x, paddle.transform.position.y + .3f, 0f);

	}
	
	// Update is called once per frame

	void OnCollisionEnter2D (Collision2D trigger)
	{

		Vector2 velocityTweak = new Vector2 (Random.Range (0f, .2f), Random.Range (0f, .2f));
		audioClip.Play ();
		this.rb.velocity += velocityTweak;
	}

	void Update ()
	{
		if (!hasStarted) {

			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;

				this.rb.velocity = new Vector2 (2f, 10f);
			}
		}	
	
	}
}
