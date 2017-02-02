﻿using System.Collections;
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

	}
	
	// Update is called once per frame

	void OnCollisionEnter2D (Collision2D collision)
	{

		if (collision.gameObject != FireBall) {
			print ("Ball collided with" + collision.gameObject);
			Vector2 velocityTweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
			audioClip.Play ();
			this.rb.velocity += velocityTweak;
			print ("Ball velocity is now" + this.rb.velocity); 
		}
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
